using Lab1COS.Generators;
using Lab1COS.Helpers.WavHelper;
using Lab1COS.Model;
using Lab1COS.Utils;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1COS
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, Func<Form1, InputModel>> _models = new Dictionary<int, Func<Form1, InputModel>>()
        {
            [0] = ModelInitializer.InitGenerator,
            [1] = ModelInitializer.InitPolyGenerator,
            [2] = ModelInitializer.InitModulizedGenerator,
        };

        public Form1()
        {
            InitializeComponent();
            this.nTextBox.Text = "2000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = _models[tabControl1.SelectedIndex](this);
            var values = GetValues(model);

            PlaySound(values.Select(v => (float)v).ToList());
        }

        private static void PlaySound(List<float> samples)
        {
            const ushort numOfChannels = 1;
            const int sampleRate = 44100;

            var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, numOfChannels);
            ISampleProvider stream = new WavStream(waveFormat, samples);
            WaveFileWriter.CreateWaveFile16("generated_sound.wav", stream);

            var player = new SoundPlayer("generated_sound.wav");

            player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var model = _models[tabControl1.SelectedIndex](this);
            var values = GetValues(model);

            resultChart.ChartAreas[0].AxisX.Minimum = 0;
            resultChart.ChartAreas[0].AxisX.Maximum = model.N;
            resultChart.Series.Clear();

            DrawChart(values);

            resultChart.ChartAreas[0].AxisY.Minimum = resultChart.Series.Min(
                series => series.Points.Min(point => point.YValues.Min())
            ) - 0.1;
            resultChart.ChartAreas[0].AxisY.Maximum = resultChart.Series.Max(
                series => series.Points.Max(point => point.YValues.Max())
            ) + 0.1;

            //_drawCharts[TaskComboBox.Text](ResultChart, model);
        }

        private void DrawChart(IReadOnlyList<double> values)
        {
            var series = new Series();
            series.ChartType = SeriesChartType.Spline;

            for (var i = 0; i < values.Count; i++)
            {
                series.Points.AddXY(i, values[i]);
            }

            resultChart.Series.Add(series);
        }

        private double[] GetValues(InputModel model)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        var generator = SignalFabric.GetGenerator(comboBox1.Text, model.A[0], model.F[0], model.Fi[0], model.WorkingCycle[0], model.N);
                        generator.Generate();
                        return generator.Values;
                    }
                case 1:
                    {
                        var generators = new Generator[]
                        {
                            SignalFabric.GetGenerator(comboBox5.Text, model.A[0], model.F[0], model.Fi[0], model.WorkingCycle[0], model.N),
                            SignalFabric.GetGenerator(comboBox4.Text, model.A[1], model.F[1], model.Fi[1], model.WorkingCycle[1], model.N)
                        };
                        var generator = new PolyGenerator(model.A, model.F, model.Fi, model.N, 2, generators);
                        return generator.Values;
                    }
                case 2:
                    {
                        switch (typeComboBox.Text)
                        {
                            case "амплитудная":
                                return Modulation.AmplitudeModulation(
                                    SignalFabric.GetGenerator(comboBox2.Text, model.A[0], model.F[0], model.Fi[0], model.WorkingCycle[0], model.N),
                                    SignalFabric.GetGenerator(comboBox3.Text, model.A[1], model.F[1], model.Fi[1], model.WorkingCycle[1], model.N)
                                    );
                            case "частотная":
                                return Modulation.FrequencyModulation(
                                    SignalFabric.GetGenerator(comboBox2.Text, model.A[0], model.F[0], model.Fi[0], model.WorkingCycle[0], model.N),
                                    SignalFabric.GetGenerator(comboBox3.Text, model.A[1], model.F[1], model.Fi[1], model.WorkingCycle[1], model.N)
                                    );
                        }

                        return null;
                    }
            }

            return null;
        }

        private void wellRateTrackBar_Scroll(object sender, EventArgs e)
        {
            var trackBar = (sender as TrackBar);
            if (trackBar == null) return;
            var value = (trackBar.Value / 100.0).ToString();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        tab1WellRateText.Text = value;
                        break;
                    }
                case 1:
                    {
                        if (trackBar == tab2WellRate1)
                        {
                            tab2WellRate1Text.Text = value;
                        }
                        else
                        {
                            tab2WellRate2Text.Text = value;
                        }

                        break;
                    }
                case 2:
                    {
                        if (trackBar == tab3WellRate1)
                        {
                            tab3WellRate1Text.Text = value;
                        }
                        else
                        {
                            tab3WellRate2Text.Text = value;
                        }

                        break;
                    }
            }
        }
    }
}
