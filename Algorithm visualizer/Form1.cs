using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_visualizer
{
    public partial class form_algorithmvisualizer : Form
    {
        private int[] array; // Array to sort
        private Graphics graphics;
        private int barWidth = 10; // Width of each bar
        private bool isSorting = false;
        private int size = 76;

        public form_algorithmvisualizer()
        {
            InitializeComponent();
            this.Text = "Algorithm Visualizer";
            this.Width = 800;
            this.Height = 600;

            cb_action.Items.Add("Bubble Sort");
            cb_action.Items.Add("Selection Sort");
            cb_action.Items.Add("Quick Sort");
            cb_action.SelectedIndex = 0; // Default to the first algorithm

            // Create panel for visualization
            var panel = new Panel
            {
                Location = new Point(10, 50),
                Width = 760,
                Height = 500,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panel);
            graphics = panel.CreateGraphics();
            size = panel.Width / barWidth;
            GenerateRandomArray();
        }

        private void btn_action_Click( object sender, EventArgs e )
        {
            StartSorting(cb_action.SelectedItem.ToString());
        }



        private void StartSorting( string algorithm )
        {
            if(isSorting) return; // Prevent starting a new sort while one is in progress

            isSorting = true;
            GenerateRandomArray();
            DrawArray();
            switch(algorithm)
            {
                case "Bubble Sort":
                btn_action.Enabled = false;
                Task.Run(() => BubbleSort());
                btn_action.Enabled = true;
                break;
                case "Selection Sort":
                btn_action.Enabled = false;
                Task.Run(() => SelectionSort());
                btn_action.Enabled = true;
                break;
                case "Quick Sort":
                Task.Run(() => QuickSort(0, array.Length - 1).ContinueWith(_ => isSorting = false));
                break;
                default:
                MessageBox.Show("Algorithm not implemented!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isSorting = false;
                break;
            }
        }


        private void GenerateRandomArray()
        {
            Random random = new Random();
            array = new int[size];
            for(int i = 0; i < size; i++)
            {
                array[i] = random.Next(10, 500); // Random heights for bars
            }
            DrawArray();
        }

        private void DrawArray()
        {
            if(graphics == null) return;
            graphics.Clear(Color.White);
            for(int i = 0; i < array.Length; i++)
            {
                graphics.FillRectangle(Brushes.Black, i * barWidth, 500 - array[i], barWidth - 1, array[i]);
            }
        }

        private async Task BubbleSort()
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        // Swap elements
                        //int temp = array[j];
                        //array[j] = array[j + 1];
                        //array[j + 1] = temp;
                        Swap(j, j + 1);

                        // Visualize the change
                        DrawArray();
                        await Task.Delay(10); // Pause to see the change
                    }
                }
            }
            isSorting = false;
        }

        private async Task SelectionSort()
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                // Find the smallest element in the unsorted section
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the found minimum with the first element
                Swap(minIndex, i);

                // Visualize the change
                DrawArray();
                await Task.Delay(50); // Adjust the delay for better visualization
            }
            isSorting = false;
        }

        private async Task QuickSort( int low, int high )
        {
            if(low < high)
            {
                int pivotIndex = await Partition(low, high);
                await QuickSort(low, pivotIndex - 1);
                await QuickSort(pivotIndex + 1, high);
            }
        }

        private async Task<int> Partition( int low, int high )
        {
            int pivot = array[high];
            int i = low - 1;

            for(int j = low; j < high; j++)
            {
                if(array[j] < pivot)
                {
                    i++;
                    Swap(i, j);

                    // Visualize the swap
                    DrawArray();
                    await Task.Delay(50); // Adjust for visualization speed
                }
            }

            Swap(i + 1, high);

            // Visualize the pivot swap
            DrawArray();
            await Task.Delay(50);

            return i + 1;
        }

        private void Swap( int index1, int index2 )
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
