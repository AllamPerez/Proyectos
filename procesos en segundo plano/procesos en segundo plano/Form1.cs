using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace procesos_en_segundo_plano
{
    public partial class Form1 : Form
    {

        // Datos base
        private List<int> listaOriginal;
        private List<int> listaBurbuja;
        private List<int> listaQuick;
        private List<int> listaMerge;
        private List<int> listaSelection;

        // Hilos
        private Thread hiloBurbuja;
        private Thread hiloSelection;

        // Cancelación
        private CancellationTokenSource ctsBurbuja;
        private CancellationTokenSource ctsSelection;

        // Tiempos
        private readonly Stopwatch relojBurbuja = new Stopwatch();
        private readonly Stopwatch relojQuick = new Stopwatch();
        private readonly Stopwatch relojMerge = new Stopwatch();
        private readonly Stopwatch relojSelection = new Stopwatch();

        // Estados
        private volatile bool burbujaTerminada;
        private volatile bool quickTerminada;
        private volatile bool mergeTerminada;
        private volatile bool selectionTerminada;

        // Límites prácticos para demo
        private const int LOG_CAP = 2000;         // máx líneas de log por algoritmo

        // Log de iteraciones (para la exportación)
        private readonly object logLock = new object();
        private readonly Dictionary<string, List<string>> logs =
            new Dictionary<string, List<string>>
            {
                {"Burbuja", new List<string>()},
                {"QuickSort", new List<string>()},
                {"MergeSort", new List<string>()},
                {"SelectionSort", new List<string>()}
            };

        private bool LogHabilitado => chkLogIteraciones.Checked;

        public Form1()
        {
            InitializeComponent();

            btnExportar.Enabled = chkLogIteraciones.Checked; // arranca en coherencia con el checkbox

            // Asegura textos iniciales
            lblBurbuja.Text = "Burbuja: 0%";
            lblQuickSort.Text = "QuickSort: 0%";
            lblMerge.Text = "MergeSort: 0%";
            lblSelection.Text = "SelectionSort: 0%";

            // Workers
            backgroundWorkerQuickSort.WorkerReportsProgress = true;
            backgroundWorkerQuickSort.WorkerSupportsCancellation = true;

            backgroundWorkerMergeSort.WorkerReportsProgress = true;
            backgroundWorkerMergeSort.WorkerSupportsCancellation = true;

            // Chart inicial (si existe en el formulario)
            if (chtTiempos != null)
            {
                chtTiempos.Series.Clear();
                chtTiempos.ChartAreas.Clear();
                chtTiempos.ChartAreas.Add(new ChartArea("Area"));
            }
        }

        private void chkLogIteraciones_CheckedChanged(object sender, EventArgs e)
        {
            btnExportar.Enabled = chkLogIteraciones.Checked;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)numCantidad.Value;
            var rnd = new Random();

            listaOriginal = new List<int>(capacity: cantidad);
            for (int i = 0; i < cantidad; i++)
                listaOriginal.Add(rnd.Next(0, 1_000_000));

            // Reset UI
            progressBurbuja.Value = 0; lblBurbuja.Text = "Burbuja: 0%";
            progressQuickSort.Value = 0; lblQuickSort.Text = "QuickSort: 0%";
            progressMerge.Value = 0; lblMerge.Text = "MergeSort: 0%"; lblTiempoMerge.Text = "Tiempo: —";
            progressSelection.Value = 0; lblSelection.Text = "SelectionSort: 0%"; lblTiempoSelection.Text = "Tiempo: —";

            if (chtTiempos != null) { chtTiempos.Series.Clear(); }

            MessageBox.Show($"Lista generada con {cantidad:N0} números.", "OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetChart();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            _uiFinalizada = 0;
            ResetChart();


            if (listaOriginal == null || listaOriginal.Count == 0)
            {
                MessageBox.Show("Primero genera los datos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LogHabilitado && listaOriginal.Count > 5000)
            {
                var r = MessageBox.Show(
                    "Guardar iteraciones con más de 5,000 elementos puede ser lento y el archivo será grande. ¿Continuar?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (r == DialogResult.No)
                {
                    chkLogIteraciones.Checked = false;   // desactiva el log
                    btnExportar.Enabled = false;         // por si usas el tip 1
                }
            }


            // Preparar listas (recortes para Burbuja)
            listaBurbuja = new List<int>(listaOriginal);
            listaQuick = new List<int>(listaOriginal);
            listaMerge = new List<int>(listaOriginal);
            listaSelection = new List<int>(listaOriginal);

            // Estados
            burbujaTerminada = quickTerminada = mergeTerminada = selectionTerminada = false;

            // UI
            btnGenerar.Enabled = false;
            btnIniciar.Enabled = false;
            btnDetener.Enabled = true;

            // Limpiar logs si se pide
            lock (logLock)
            {
                foreach (var k in logs.Keys.ToList())
                    logs[k].Clear();
            }

            // Cancelaciones
            ctsBurbuja = new CancellationTokenSource();
            ctsSelection = new CancellationTokenSource();

            // Lanzar Burbuja (Thread)
            hiloBurbuja = new Thread(() => OrdenarBurbuja(ctsBurbuja.Token)) { IsBackground = true };
            hiloBurbuja.Start();

            // Lanzar QuickSort (BackgroundWorker)
            if (!backgroundWorkerQuickSort.IsBusy)
                backgroundWorkerQuickSort.RunWorkerAsync(listaQuick);

            // Lanzar MergeSort (BackgroundWorker)
            if (!backgroundWorkerMergeSort.IsBusy)
                backgroundWorkerMergeSort.RunWorkerAsync(listaMerge);

            // Lanzar SelectionSort (Thread)
            hiloSelection = new Thread(() => SelectionSortThread(ctsSelection.Token)) { IsBackground = true };
            hiloSelection.Start();
        }

        // Firma corregida: acepta el token de cancelación
        private void OrdenarBurbuja(CancellationToken token)
        {
            relojBurbuja.Restart();
            int n = listaBurbuja.Count;
            bool intercambio;

            for (int i = 0; i < n - 1; i++)
            {
                if (token.IsCancellationRequested) break;

                intercambio = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (token.IsCancellationRequested) break;

                    if (listaBurbuja[j] > listaBurbuja[j + 1])
                    {
                        int tmp = listaBurbuja[j];
                        listaBurbuja[j] = listaBurbuja[j + 1];
                        listaBurbuja[j + 1] = tmp;
                        intercambio = true;

                        if (LogHabilitado) AgregarLog("Burbuja", $"i={i}, swap j={j}↔{j + 1}, [{listaBurbuja[j]}, {listaBurbuja[j + 1]}]");
                    }
                }

                if (i % 200 == 0) // throttling UI
                {
                    int progreso = (int)(i * 100.0 / (n - 1));
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBurbuja.Value = Math.Max(0, Math.Min(100, progreso));
                        lblBurbuja.Text = $"Burbuja: {progreso}%";
                    }));
                }

                if (!intercambio) break;
            }

            relojBurbuja.Stop();

            this.BeginInvoke(new Action(() =>
            {
                if (token.IsCancellationRequested)
                {
                    lblBurbuja.Text = $"Burbuja: Cancelado ({relojBurbuja.ElapsedMilliseconds} ms)";
                }
                else
                {
                    progressBurbuja.Value = 100;
                    lblBurbuja.Text = $"Burbuja: 100% ({relojBurbuja.ElapsedMilliseconds} ms)";

                }
            }));

            burbujaTerminada = true;
            PintarChartParcial();
            FinalizarSiListo();
        }


        private void backgroundWorkerQuickSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojQuick.Restart();
            var lista = (List<int>)e.Argument;
            QuickSortIterativoConProgreso(lista, backgroundWorkerQuickSort, e);
        }

        private void backgroundWorkerQuickSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int p = Math.Max(0, Math.Min(100, e.ProgressPercentage));
            progressQuickSort.Value = p;
            lblQuickSort.Text = $"QuickSort: {p}%";
        }

        private void backgroundWorkerQuickSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            relojQuick.Stop();
            if (e.Cancelled)
                lblQuickSort.Text = $"QuickSort: Cancelado ({relojQuick.ElapsedMilliseconds} ms)";
            else
            {
                progressQuickSort.Value = 100;
                lblQuickSort.Text = $"QuickSort: 100% ({relojQuick.ElapsedMilliseconds} ms)";
            }

            quickTerminada = true;
            PintarChartParcial();
            FinalizarSiListo();
        }

        private void QuickSortIterativoConProgreso(List<int> a, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int n = a.Count;
            if (n <= 1) { worker.ReportProgress(100); return; }

            var stack = new Stack<(int l, int r)>();
            stack.Push((0, n - 1));

            int procesados = 0;

            while (stack.Count > 0)
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }

                var (l, r) = stack.Pop();
                if (l >= r) { procesados++; ReportIfNeeded(); continue; }

                int p = Particionar(a, l, r);
                procesados++; ReportIfNeeded();

                if (LogHabilitado) AgregarLog("QuickSort", $"pivot={p}, rango=({l},{r})");

                if (p - 1 > l) stack.Push((l, p - 1));
                if (p + 1 < r) stack.Push((p + 1, r));

                void ReportIfNeeded()
                {
                    if (procesados % 800 == 0)
                        worker.ReportProgress(Math.Min(100, (int)(procesados * 100.0 / n)));
                }
            }

            worker.ReportProgress(100);
        }

        private int Particionar(List<int> a, int l, int r)
        {
            int pivote = a[r];
            int i = l - 1;
            for (int j = l; j < r; j++)
            {
                if (a[j] <= pivote)
                {
                    i++;
                    (a[i], a[j]) = (a[j], a[i]);
                }
            }
            (a[i + 1], a[r]) = (a[r], a[i + 1]);
            return i + 1;
        }

        private int _uiFinalizada = 0;
        private void FinalizarSiListo()
        {
            // si aún falta algún algoritmo, salimos
            if (!(burbujaTerminada && quickTerminada && mergeTerminada && selectionTerminada))
                return;

            // si NO estamos en el hilo de la UI, volver a invocar en el hilo correcto
            if (this.IsHandleCreated && this.InvokeRequired)
            {
                try { this.BeginInvoke(new Action(FinalizarSiListo)); }
                catch (ObjectDisposedException) { /* el form se cerró */ }
                return;
            }

            // asegurarnos de correr esta sección solo una vez
            if (Interlocked.Exchange(ref _uiFinalizada, 1) == 1) return;

            // --- desde aquí ya estamos en el hilo de la UI ---
            btnDetener.Enabled = false;
            btnGenerar.Enabled = true;
            btnIniciar.Enabled = true;

            if (chtTiempos != null)
            {
                chtTiempos.Series.Clear();
                var serie = new System.Windows.Forms.DataVisualization.Charting.Series("Tiempos (ms)")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                serie.Points.AddXY("Burbuja", relojBurbuja.ElapsedMilliseconds);
                serie.Points.AddXY("QuickSort", relojQuick.ElapsedMilliseconds);
                serie.Points.AddXY("MergeSort", relojMerge.ElapsedMilliseconds);
                serie.Points.AddXY("SelectionSort", relojSelection.ElapsedMilliseconds);
                chtTiempos.Series.Add(serie);
            }
        }


        private void btnDetener_Click(object sender, EventArgs e)
        {
            // Evita doble clic mientras cancelas
            btnDetener.Enabled = false;

            // 1) Señal de cancelación
            if (backgroundWorkerQuickSort.IsBusy)
                backgroundWorkerQuickSort.CancelAsync();
            if (backgroundWorkerMergeSort.IsBusy)
                backgroundWorkerMergeSort.CancelAsync();

            ctsBurbuja?.Cancel();
            ctsSelection?.Cancel();

            
            PintarChartParcial();   

         
            new Thread(() =>
            {
                // Espera máx. 2s a que acaben los hilos manuales
                hiloBurbuja?.Join(2000);
                hiloSelection?.Join(2000);

                // Vuelve al hilo de UI
                this.BeginInvoke(new Action(() =>
                {
                    
                    PintarChartParcial();   

                    // Reactiva botones
                    btnGenerar.Enabled = true;
                    btnIniciar.Enabled = true;
                    
                }));
            }).Start();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!HayLogs())
            {
                MessageBox.Show(
                    "No hay iteraciones registradas. Marca 'Guardar iteraciones (demo)' y vuelve a ejecutar.",
                    "Sin datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Title = "Guardar iteraciones",
                Filter = "Documento RTF (*.rtf)|*.rtf",
                FileName = "IteracionesOrdenamiento.rtf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarLogsComoRtf(sfd.FileName);
                    MessageBox.Show("Archivo exportado.", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void backgroundWorkerMergeSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojMerge.Restart();
            var a = (List<int>)e.Argument;
            MergeSortBottomUp(a, backgroundWorkerMergeSort, e);
        }

        private void backgroundWorkerMergeSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int p = Math.Max(0, Math.Min(100, e.ProgressPercentage));
            progressMerge.Value = p;
            lblMerge.Text = $"MergeSort: {p}%";
        }

        private void backgroundWorkerMergeSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            relojMerge.Stop();

            if (e.Cancelled)
                lblMerge.Text = $"MergeSort: Cancelado ({relojMerge.ElapsedMilliseconds} ms)";
            else
            {
                progressMerge.Value = 100;
                lblMerge.Text = $"MergeSort: 100% ({relojMerge.ElapsedMilliseconds} ms)";
            }

            mergeTerminada = true;
            PintarChartParcial();
            FinalizarSiListo();
        }

        private void MergeSortBottomUp(List<int> a, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int n = a.Count;
            int width;
            var aux = new int[n];

            for (width = 1; width < n; width *= 2)
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }

                for (int i = 0; i < n; i += 2 * width)
                {
                    if (worker.CancellationPending) { e.Cancel = true; return; }

                    int left = i;
                    int mid = Math.Min(i + width, n);
                    int right = Math.Min(i + 2 * width, n);

                    Merge(a, aux, left, mid, right);
                    if (LogHabilitado) AgregarLog("MergeSort", $"merge [{left},{mid}) + [{mid},{right})");
                }

                // reporte de progreso aproximado
                int progreso = Math.Min(100, (int)(Math.Log(width * 2, 2) * 100.0 / Math.Log(n == 0 ? 1 : n, 2)));
                worker.ReportProgress(progreso);
            }

            // copia final a 'a' si quedó en aux (número impar de pasadas)
            // (nuestras fusiones ya dejan el resultado en 'a', no es necesaria copia extra)
            worker.ReportProgress(100);
        }

        private void Merge(List<int> a, int[] aux, int left, int mid, int right)
        {
            int i = left, j = mid, k = left;
            while (i < mid && j < right)
            {
                if (a[i] <= a[j]) aux[k++] = a[i++];
                else aux[k++] = a[j++];
            }
            while (i < mid) aux[k++] = a[i++];
            while (j < right) aux[k++] = a[j++];

            for (int t = left; t < right; t++) a[t] = aux[t];
        }

        private void SelectionSortThread(CancellationToken token)
        {
            relojSelection.Restart();

            int n = listaSelection.Count;
            for (int i = 0; i < n - 1; i++)
            {
                if (token.IsCancellationRequested) break;

                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (token.IsCancellationRequested) break;

                    if (listaSelection[j] < listaSelection[minIdx])
                        minIdx = j;
                }

                if (minIdx != i)
                {
                    (listaSelection[i], listaSelection[minIdx]) = (listaSelection[minIdx], listaSelection[i]);
                    if (LogHabilitado) AgregarLog("SelectionSort", $"i={i}, minIdx={minIdx}, val={listaSelection[i]}");
                }

                if (i % 500 == 0)
                {
                    int progreso = (int)(i * 100.0 / (n - 1));
                    int p = Math.Min(100, Math.Max(0, progreso));
                    this.BeginInvoke(new Action(() =>
                    {
                        progressSelection.Value = p;
                        lblSelection.Text = $"SelectionSort: {p}%";
                    }));
                }
            }

            relojSelection.Stop();

            this.BeginInvoke(new Action(() =>
            {
                if (token.IsCancellationRequested)
                    lblSelection.Text = $"SelectionSort: Cancelado ({relojSelection.ElapsedMilliseconds} ms)";
                else
                {
                    progressSelection.Value = 100;
                    lblSelection.Text = $"SelectionSort: 100% ({relojSelection.ElapsedMilliseconds} ms)";
                }
            }));

            selectionTerminada = true;
            PintarChartParcial();
            FinalizarSiListo();
        }

        private void AgregarLog(string algoritmo, string linea)
        {
            if (!LogHabilitado) return;

            lock (logLock)
            {
                var l = logs[algoritmo];
                if (l.Count < LOG_CAP) l.Add(linea);
            }
        }

        

        private void ExportarLogsComoRtf(string ruta)
        {
            using (var rtb = new RichTextBox())
            {
                rtb.AppendText("Iteraciones de Ordenamiento\n");
                rtb.AppendText("===========================\n\n");

                lock (logLock)
                {
                    foreach (var kv in logs)
                    {
                        rtb.AppendText($"[{kv.Key}]\n");
                        if (kv.Value.Count == 0)
                        {
                            rtb.AppendText("  (Sin registros o no se habilitó el log)\n\n");
                            continue;
                        }
                        foreach (var line in kv.Value)
                            rtb.AppendText($"  - {line}\n");
                        if (kv.Value.Count >= LOG_CAP)
                            rtb.AppendText($"  ... (capado a {LOG_CAP} líneas)\n");
                        rtb.AppendText("\n");
                    }
                }

                rtb.SaveFile(ruta, RichTextBoxStreamType.RichText);
            }
        }

        private void ResetChart()
        {
            if (chtTiempos == null) return;
            if (this.IsHandleCreated && this.InvokeRequired) { BeginInvoke(new Action(ResetChart)); return; }

            chtTiempos.Series.Clear();
            chtTiempos.ChartAreas.Clear();

            var area = new ChartArea("Area");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chtTiempos.ChartAreas.Add(area);
        }

        private void PintarChartParcial()
        {
            if (chtTiempos == null) return;

            // Volver al hilo de UI si hace falta
            if (this.IsHandleCreated && this.InvokeRequired)
            {
                this.BeginInvoke(new Action(PintarChartParcial));
                return;
            }

            // Asegurar área y serie
            if (chtTiempos.ChartAreas.Count == 0)
            {
                var area = new ChartArea("Area");
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chtTiempos.ChartAreas.Add(area);
            }
            if (chtTiempos.Series.Count == 0)
            {
                var serieNueva = new Series("Tiempos (ms)")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };
                chtTiempos.Series.Add(serieNueva);
            }

            var serie = chtTiempos.Series[0];
            serie.Points.Clear();

            if (burbujaTerminada) serie.Points.AddXY("Burbuja", relojBurbuja.ElapsedMilliseconds);
            if (quickTerminada) serie.Points.AddXY("QuickSort", relojQuick.ElapsedMilliseconds);
            if (mergeTerminada) serie.Points.AddXY("MergeSort", relojMerge.ElapsedMilliseconds);
            if (selectionTerminada) serie.Points.AddXY("SelectionSort", relojSelection.ElapsedMilliseconds);
        }

        private bool HayLogs()
        {
            lock (logLock)
                return logs.Any(kv => kv.Value.Count > 0);
        }

    }
}
