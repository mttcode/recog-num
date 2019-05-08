using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecogNum
{
    public partial class Form1 : Form
    {
        Button[,] grid;
        int[] map;

        const double PI = 3.1415926;
        const double RO = 0.1;
        const int inputNeurons = 100;
        const int hiddenNeurons = 50;
        const int outputNeurons = 10;

        double[] inputs;
        double[] hidden;
        double[] outputs;

        double[,] w_h_i;
        double[,] w_o_h;

        int[,] image;
        int[,] output;


        public Form1()
        {
            InitializeComponent();

            grid = new Button[150, 150];

            inputs = new double[101];
            hidden = new double[51];
            outputs = new double[10];

            w_h_i = new double[50, 101];
            w_o_h = new double[10, 51];

            image = new int[10, 100];
            output = new int[10, 10];

            #region init_image
            image[0, 0] = 0; image[0, 1] = 0; image[0, 2] = 1; image[0, 3] = 1; image[0, 4] = 1; image[0, 5] = 1; image[0, 6] = 1; image[0, 7] = 1; image[0, 8] = 0; image[0, 9] = 0; image[0, 10] = 0; image[0, 11] = 1; image[0, 12] = 0; image[0, 13] = 0; image[0, 14] = 0; image[0, 15] = 0; image[0, 16] = 0; image[0, 17] = 0; image[0, 18] = 1; image[0, 19] = 0; image[0, 20] = 0; image[0, 21] = 1; image[0, 22] = 0; image[0, 23] = 0; image[0, 24] = 0; image[0, 25] = 0; image[0, 26] = 0; image[0, 27] = 0; image[0, 28] = 1; image[0, 29] = 0; image[0, 30] = 0; image[0, 31] = 1; image[0, 32] = 0; image[0, 33] = 0; image[0, 34] = 0; image[0, 35] = 0; image[0, 36] = 0; image[0, 37] = 0; image[0, 38] = 1; image[0, 39] = 0; image[0, 40] = 0; image[0, 41] = 1; image[0, 42] = 0; image[0, 43] = 0; image[0, 44] = 0; image[0, 45] = 0; image[0, 46] = 0; image[0, 47] = 0; image[0, 48] = 1; image[0, 49] = 0; image[0, 50] = 0; image[0, 51] = 1; image[0, 52] = 0; image[0, 53] = 0; image[0, 54] = 0; image[0, 55] = 0; image[0, 56] = 0; image[0, 57] = 0; image[0, 58] = 1; image[0, 59] = 0; image[0, 60] = 0; image[0, 61] = 1; image[0, 62] = 0; image[0, 63] = 0; image[0, 64] = 0; image[0, 65] = 0; image[0, 66] = 0; image[0, 67] = 0; image[0, 68] = 1; image[0, 69] = 0; image[0, 70] = 0; image[0, 71] = 1; image[0, 72] = 0; image[0, 73] = 0; image[0, 74] = 0; image[0, 75] = 0; image[0, 76] = 0; image[0, 77] = 0; image[0, 78] = 1; image[0, 79] = 0; image[0, 80] = 0; image[0, 81] = 1; image[0, 82] = 0; image[0, 83] = 0; image[0, 84] = 0; image[0, 85] = 0; image[0, 86] = 0; image[0, 87] = 0; image[0, 88] = 1; image[0, 89] = 0; image[0, 90] = 0; image[0, 91] = 0; image[0, 92] = 1; image[0, 93] = 1; image[0, 94] = 1; image[0, 95] = 1; image[0, 96] = 1; image[0, 97] = 1; image[0, 98] = 0; image[0, 99] = 0;
            image[1, 0] = 0; image[1, 1] = 0; image[1, 2] = 0; image[1, 3] = 0; image[1, 4] = 0; image[1, 5] = 1; image[1, 6] = 0; image[1, 7] = 0; image[1, 8] = 0; image[1, 9] = 0; image[1, 10] = 0; image[1, 11] = 0; image[1, 12] = 0; image[1, 13] = 0; image[1, 14] = 1; image[1, 15] = 1; image[1, 16] = 0; image[1, 17] = 0; image[1, 18] = 0; image[1, 19] = 0; image[1, 20] = 0; image[1, 21] = 0; image[1, 22] = 0; image[1, 23] = 1; image[1, 24] = 0; image[1, 25] = 1; image[1, 26] = 0; image[1, 27] = 0; image[1, 28] = 0; image[1, 29] = 0; image[1, 30] = 0; image[1, 31] = 0; image[1, 32] = 1; image[1, 33] = 0; image[1, 34] = 0; image[1, 35] = 1; image[1, 36] = 0; image[1, 37] = 0; image[1, 38] = 0; image[1, 39] = 0; image[1, 40] = 0; image[1, 41] = 0; image[1, 42] = 0; image[1, 43] = 0; image[1, 44] = 0; image[1, 45] = 1; image[1, 46] = 0; image[1, 47] = 0; image[1, 48] = 0; image[1, 49] = 0; image[1, 50] = 0; image[1, 51] = 0; image[1, 52] = 0; image[1, 53] = 0; image[1, 54] = 0; image[1, 55] = 1; image[1, 56] = 0; image[1, 57] = 0; image[1, 58] = 0; image[1, 59] = 0; image[1, 60] = 0; image[1, 61] = 0; image[1, 62] = 0; image[1, 63] = 0; image[1, 64] = 0; image[1, 65] = 1; image[1, 66] = 0; image[1, 67] = 0; image[1, 68] = 0; image[1, 69] = 0; image[1, 70] = 0; image[1, 71] = 0; image[1, 72] = 0; image[1, 73] = 0; image[1, 74] = 0; image[1, 75] = 1; image[1, 76] = 0; image[1, 77] = 0; image[1, 78] = 0; image[1, 79] = 0; image[1, 80] = 0; image[1, 81] = 0; image[1, 82] = 0; image[1, 83] = 0; image[1, 84] = 0; image[1, 85] = 1; image[1, 86] = 0; image[1, 87] = 0; image[1, 88] = 0; image[1, 89] = 0; image[1, 90] = 0; image[1, 91] = 0; image[1, 92] = 0; image[1, 93] = 0; image[1, 94] = 0; image[1, 95] = 1; image[1, 96] = 0; image[1, 97] = 0; image[1, 98] = 0; image[1, 99] = 0;
            image[2, 0] = 0; image[2, 1] = 0; image[2, 2] = 1; image[2, 3] = 1; image[2, 4] = 1; image[2, 5] = 1; image[2, 6] = 1; image[2, 7] = 1; image[2, 8] = 0; image[2, 9] = 0; image[2, 10] = 0; image[2, 11] = 1; image[2, 12] = 0; image[2, 13] = 0; image[2, 14] = 0; image[2, 15] = 0; image[2, 16] = 0; image[2, 17] = 0; image[2, 18] = 1; image[2, 19] = 0; image[2, 20] = 0; image[2, 21] = 0; image[2, 22] = 0; image[2, 23] = 0; image[2, 24] = 0; image[2, 25] = 0; image[2, 26] = 0; image[2, 27] = 0; image[2, 28] = 1; image[2, 29] = 0; image[2, 30] = 0; image[2, 31] = 0; image[2, 32] = 0; image[2, 33] = 0; image[2, 34] = 0; image[2, 35] = 0; image[2, 36] = 0; image[2, 37] = 0; image[2, 38] = 1; image[2, 39] = 0; image[2, 40] = 0; image[2, 41] = 0; image[2, 42] = 0; image[2, 43] = 0; image[2, 44] = 0; image[2, 45] = 0; image[2, 46] = 0; image[2, 47] = 1; image[2, 48] = 0; image[2, 49] = 0; image[2, 50] = 0; image[2, 51] = 0; image[2, 52] = 1; image[2, 53] = 1; image[2, 54] = 1; image[2, 55] = 1; image[2, 56] = 1; image[2, 57] = 0; image[2, 58] = 0; image[2, 59] = 0; image[2, 60] = 0; image[2, 61] = 1; image[2, 62] = 0; image[2, 63] = 0; image[2, 64] = 0; image[2, 65] = 0; image[2, 66] = 0; image[2, 67] = 0; image[2, 68] = 0; image[2, 69] = 0; image[2, 70] = 0; image[2, 71] = 1; image[2, 72] = 0; image[2, 73] = 0; image[2, 74] = 0; image[2, 75] = 0; image[2, 76] = 0; image[2, 77] = 0; image[2, 78] = 0; image[2, 79] = 0; image[2, 80] = 0; image[2, 81] = 1; image[2, 82] = 0; image[2, 83] = 0; image[2, 84] = 0; image[2, 85] = 0; image[2, 86] = 0; image[2, 87] = 0; image[2, 88] = 0; image[2, 89] = 0; image[2, 90] = 0; image[2, 91] = 0; image[2, 92] = 1; image[2, 93] = 1; image[2, 94] = 1; image[2, 95] = 1; image[2, 96] = 1; image[2, 97] = 1; image[2, 98] = 1; image[2, 99] = 0;
            image[3, 0] = 0; image[3, 1] = 0; image[3, 2] = 1; image[3, 3] = 1; image[3, 4] = 1; image[3, 5] = 1; image[3, 6] = 1; image[3, 7] = 1; image[3, 8] = 0; image[3, 9] = 0; image[3, 10] = 0; image[3, 11] = 1; image[3, 12] = 0; image[3, 13] = 0; image[3, 14] = 0; image[3, 15] = 0; image[3, 16] = 0; image[3, 17] = 0; image[3, 18] = 1; image[3, 19] = 0; image[3, 20] = 0; image[3, 21] = 0; image[3, 22] = 0; image[3, 23] = 0; image[3, 24] = 0; image[3, 25] = 0; image[3, 26] = 0; image[3, 27] = 0; image[3, 28] = 1; image[3, 29] = 0; image[3, 30] = 0; image[3, 31] = 0; image[3, 32] = 0; image[3, 33] = 0; image[3, 34] = 0; image[3, 35] = 0; image[3, 36] = 0; image[3, 37] = 0; image[3, 38] = 1; image[3, 39] = 0; image[3, 40] = 0; image[3, 41] = 0; image[3, 42] = 0; image[3, 43] = 0; image[3, 44] = 0; image[3, 45] = 0; image[3, 46] = 0; image[3, 47] = 0; image[3, 48] = 1; image[3, 49] = 0; image[3, 50] = 0; image[3, 51] = 0; image[3, 52] = 0; image[3, 53] = 0; image[3, 54] = 1; image[3, 55] = 1; image[3, 56] = 1; image[3, 57] = 1; image[3, 58] = 0; image[3, 59] = 0; image[3, 60] = 0; image[3, 61] = 0; image[3, 62] = 0; image[3, 63] = 0; image[3, 64] = 0; image[3, 65] = 0; image[3, 66] = 0; image[3, 67] = 0; image[3, 68] = 1; image[3, 69] = 0; image[3, 70] = 0; image[3, 71] = 0; image[3, 72] = 0; image[3, 73] = 0; image[3, 74] = 0; image[3, 75] = 0; image[3, 76] = 0; image[3, 77] = 0; image[3, 78] = 1; image[3, 79] = 0; image[3, 80] = 0; image[3, 81] = 1; image[3, 82] = 0; image[3, 83] = 0; image[3, 84] = 0; image[3, 85] = 0; image[3, 86] = 0; image[3, 87] = 0; image[3, 88] = 1; image[3, 89] = 0; image[3, 90] = 0; image[3, 91] = 0; image[3, 92] = 1; image[3, 93] = 1; image[3, 94] = 1; image[3, 95] = 1; image[3, 96] = 1; image[3, 97] = 1; image[3, 98] = 0; image[3, 99] = 0;
            image[4, 0] = 0; image[4, 1] = 0; image[4, 2] = 0; image[4, 3] = 0; image[4, 4] = 0; image[4, 5] = 1; image[4, 6] = 0; image[4, 7] = 0; image[4, 8] = 0; image[4, 9] = 0; image[4, 10] = 0; image[4, 11] = 0; image[4, 12] = 0; image[4, 13] = 0; image[4, 14] = 1; image[4, 15] = 1; image[4, 16] = 0; image[4, 17] = 0; image[4, 18] = 0; image[4, 19] = 0; image[4, 20] = 0; image[4, 21] = 0; image[4, 22] = 0; image[4, 23] = 1; image[4, 24] = 0; image[4, 25] = 1; image[4, 26] = 0; image[4, 27] = 0; image[4, 28] = 0; image[4, 29] = 0; image[4, 30] = 0; image[4, 31] = 0; image[4, 32] = 1; image[4, 33] = 0; image[4, 34] = 0; image[4, 35] = 1; image[4, 36] = 0; image[4, 37] = 0; image[4, 38] = 0; image[4, 39] = 0; image[4, 40] = 0; image[4, 41] = 1; image[4, 42] = 0; image[4, 43] = 0; image[4, 44] = 0; image[4, 45] = 1; image[4, 46] = 0; image[4, 47] = 0; image[4, 48] = 0; image[4, 49] = 0; image[4, 50] = 0; image[4, 51] = 1; image[4, 52] = 1; image[4, 53] = 1; image[4, 54] = 1; image[4, 55] = 1; image[4, 56] = 1; image[4, 57] = 1; image[4, 58] = 0; image[4, 59] = 0; image[4, 60] = 0; image[4, 61] = 0; image[4, 62] = 0; image[4, 63] = 0; image[4, 64] = 0; image[4, 65] = 1; image[4, 66] = 0; image[4, 67] = 0; image[4, 68] = 0; image[4, 69] = 0; image[4, 70] = 0; image[4, 71] = 0; image[4, 72] = 0; image[4, 73] = 0; image[4, 74] = 0; image[4, 75] = 1; image[4, 76] = 0; image[4, 77] = 0; image[4, 78] = 0; image[4, 79] = 0; image[4, 80] = 0; image[4, 81] = 0; image[4, 82] = 0; image[4, 83] = 0; image[4, 84] = 0; image[4, 85] = 1; image[4, 86] = 0; image[4, 87] = 0; image[4, 88] = 0; image[4, 89] = 0; image[4, 90] = 0; image[4, 91] = 0; image[4, 92] = 0; image[4, 93] = 0; image[4, 94] = 0; image[4, 95] = 1; image[4, 96] = 0; image[4, 97] = 0; image[4, 98] = 0; image[4, 99] = 0;
            image[5, 0] = 0; image[5, 1] = 0; image[5, 2] = 1; image[5, 3] = 1; image[5, 4] = 1; image[5, 5] = 1; image[5, 6] = 1; image[5, 7] = 1; image[5, 8] = 0; image[5, 9] = 0; image[5, 10] = 0; image[5, 11] = 1; image[5, 12] = 0; image[5, 13] = 0; image[5, 14] = 0; image[5, 15] = 0; image[5, 16] = 0; image[5, 17] = 0; image[5, 18] = 0; image[5, 19] = 0; image[5, 20] = 0; image[5, 21] = 1; image[5, 22] = 0; image[5, 23] = 0; image[5, 24] = 0; image[5, 25] = 0; image[5, 26] = 0; image[5, 27] = 0; image[5, 28] = 0; image[5, 29] = 0; image[5, 30] = 0; image[5, 31] = 1; image[5, 32] = 0; image[5, 33] = 0; image[5, 34] = 0; image[5, 35] = 0; image[5, 36] = 0; image[5, 37] = 0; image[5, 38] = 0; image[5, 39] = 0; image[5, 40] = 0; image[5, 41] = 1; image[5, 42] = 0; image[5, 43] = 0; image[5, 44] = 0; image[5, 45] = 0; image[5, 46] = 0; image[5, 47] = 0; image[5, 48] = 0; image[5, 49] = 0; image[5, 50] = 0; image[5, 51] = 0; image[5, 52] = 1; image[5, 53] = 1; image[5, 54] = 1; image[5, 55] = 1; image[5, 56] = 1; image[5, 57] = 1; image[5, 58] = 0; image[5, 59] = 0; image[5, 60] = 0; image[5, 61] = 0; image[5, 62] = 0; image[5, 63] = 0; image[5, 64] = 0; image[5, 65] = 0; image[5, 66] = 0; image[5, 67] = 0; image[5, 68] = 1; image[5, 69] = 0; image[5, 70] = 0; image[5, 71] = 0; image[5, 72] = 0; image[5, 73] = 0; image[5, 74] = 0; image[5, 75] = 0; image[5, 76] = 0; image[5, 77] = 0; image[5, 78] = 1; image[5, 79] = 0; image[5, 80] = 0; image[5, 81] = 1; image[5, 82] = 0; image[5, 83] = 0; image[5, 84] = 0; image[5, 85] = 0; image[5, 86] = 0; image[5, 87] = 0; image[5, 88] = 1; image[5, 89] = 0; image[5, 90] = 0; image[5, 91] = 0; image[5, 92] = 1; image[5, 93] = 1; image[5, 94] = 1; image[5, 95] = 1; image[5, 96] = 1; image[5, 97] = 1; image[5, 98] = 0; image[5, 99] = 0;
            image[6, 0] = 0; image[6, 1] = 0; image[6, 2] = 1; image[6, 3] = 1; image[6, 4] = 1; image[6, 5] = 1; image[6, 6] = 1; image[6, 7] = 1; image[6, 8] = 0; image[6, 9] = 0; image[6, 10] = 0; image[6, 11] = 1; image[6, 12] = 0; image[6, 13] = 0; image[6, 14] = 0; image[6, 15] = 0; image[6, 16] = 0; image[6, 17] = 0; image[6, 18] = 1; image[6, 19] = 0; image[6, 20] = 0; image[6, 21] = 1; image[6, 22] = 0; image[6, 23] = 0; image[6, 24] = 0; image[6, 25] = 0; image[6, 26] = 0; image[6, 27] = 0; image[6, 28] = 0; image[6, 29] = 0; image[6, 30] = 0; image[6, 31] = 1; image[6, 32] = 0; image[6, 33] = 0; image[6, 34] = 0; image[6, 35] = 0; image[6, 36] = 0; image[6, 37] = 0; image[6, 38] = 0; image[6, 39] = 0; image[6, 40] = 0; image[6, 41] = 1; image[6, 42] = 0; image[6, 43] = 0; image[6, 44] = 0; image[6, 45] = 0; image[6, 46] = 0; image[6, 47] = 0; image[6, 48] = 0; image[6, 49] = 0; image[6, 50] = 0; image[6, 51] = 1; image[6, 52] = 1; image[6, 53] = 1; image[6, 54] = 1; image[6, 55] = 1; image[6, 56] = 1; image[6, 57] = 1; image[6, 58] = 0; image[6, 59] = 0; image[6, 60] = 0; image[6, 61] = 1; image[6, 62] = 0; image[6, 63] = 0; image[6, 64] = 0; image[6, 65] = 0; image[6, 66] = 0; image[6, 67] = 0; image[6, 68] = 1; image[6, 69] = 0; image[6, 70] = 0; image[6, 71] = 1; image[6, 72] = 0; image[6, 73] = 0; image[6, 74] = 0; image[6, 75] = 0; image[6, 76] = 0; image[6, 77] = 0; image[6, 78] = 1; image[6, 79] = 0; image[6, 80] = 0; image[6, 81] = 1; image[6, 82] = 0; image[6, 83] = 0; image[6, 84] = 0; image[6, 85] = 0; image[6, 86] = 0; image[6, 87] = 0; image[6, 88] = 1; image[6, 89] = 0; image[6, 90] = 0; image[6, 91] = 0; image[6, 92] = 1; image[6, 93] = 1; image[6, 94] = 1; image[6, 95] = 1; image[6, 96] = 1; image[6, 97] = 1; image[6, 98] = 0; image[6, 99] = 0;
            image[7, 0] = 0; image[7, 1] = 1; image[7, 2] = 1; image[7, 3] = 1; image[7, 4] = 1; image[7, 5] = 1; image[7, 6] = 1; image[7, 7] = 1; image[7, 8] = 1; image[7, 9] = 0; image[7, 10] = 0; image[7, 11] = 0; image[7, 12] = 0; image[7, 13] = 0; image[7, 14] = 0; image[7, 15] = 0; image[7, 16] = 0; image[7, 17] = 0; image[7, 18] = 1; image[7, 19] = 0; image[7, 20] = 0; image[7, 21] = 0; image[7, 22] = 0; image[7, 23] = 0; image[7, 24] = 0; image[7, 25] = 0; image[7, 26] = 0; image[7, 27] = 1; image[7, 28] = 1; image[7, 29] = 0; image[7, 30] = 0; image[7, 31] = 0; image[7, 32] = 0; image[7, 33] = 0; image[7, 34] = 0; image[7, 35] = 0; image[7, 36] = 1; image[7, 37] = 1; image[7, 38] = 0; image[7, 39] = 0; image[7, 40] = 0; image[7, 41] = 0; image[7, 42] = 0; image[7, 43] = 0; image[7, 44] = 0; image[7, 45] = 1; image[7, 46] = 1; image[7, 47] = 0; image[7, 48] = 0; image[7, 49] = 0; image[7, 50] = 0; image[7, 51] = 0; image[7, 52] = 0; image[7, 53] = 0; image[7, 54] = 1; image[7, 55] = 1; image[7, 56] = 0; image[7, 57] = 0; image[7, 58] = 0; image[7, 59] = 0; image[7, 60] = 0; image[7, 61] = 0; image[7, 62] = 0; image[7, 63] = 1; image[7, 64] = 1; image[7, 65] = 0; image[7, 66] = 0; image[7, 67] = 0; image[7, 68] = 0; image[7, 69] = 0; image[7, 70] = 0; image[7, 71] = 0; image[7, 72] = 1; image[7, 73] = 1; image[7, 74] = 0; image[7, 75] = 0; image[7, 76] = 0; image[7, 77] = 0; image[7, 78] = 0; image[7, 79] = 0; image[7, 80] = 0; image[7, 81] = 1; image[7, 82] = 1; image[7, 83] = 0; image[7, 84] = 0; image[7, 85] = 0; image[7, 86] = 0; image[7, 87] = 0; image[7, 88] = 0; image[7, 89] = 0; image[7, 90] = 0; image[7, 91] = 1; image[7, 92] = 0; image[7, 93] = 0; image[7, 94] = 0; image[7, 95] = 0; image[7, 96] = 0; image[7, 97] = 0; image[7, 98] = 0; image[7, 99] = 0;
            image[8, 0] = 0; image[8, 1] = 0; image[8, 2] = 1; image[8, 3] = 1; image[8, 4] = 1; image[8, 5] = 1; image[8, 6] = 1; image[8, 7] = 1; image[8, 8] = 0; image[8, 9] = 0; image[8, 10] = 0; image[8, 11] = 1; image[8, 12] = 0; image[8, 13] = 0; image[8, 14] = 0; image[8, 15] = 0; image[8, 16] = 0; image[8, 17] = 0; image[8, 18] = 1; image[8, 19] = 0; image[8, 20] = 0; image[8, 21] = 1; image[8, 22] = 0; image[8, 23] = 0; image[8, 24] = 0; image[8, 25] = 0; image[8, 26] = 0; image[8, 27] = 0; image[8, 28] = 1; image[8, 29] = 0; image[8, 30] = 0; image[8, 31] = 1; image[8, 32] = 0; image[8, 33] = 0; image[8, 34] = 0; image[8, 35] = 0; image[8, 36] = 0; image[8, 37] = 0; image[8, 38] = 1; image[8, 39] = 0; image[8, 40] = 0; image[8, 41] = 1; image[8, 42] = 0; image[8, 43] = 0; image[8, 44] = 0; image[8, 45] = 0; image[8, 46] = 0; image[8, 47] = 0; image[8, 48] = 1; image[8, 49] = 0; image[8, 50] = 0; image[8, 51] = 0; image[8, 52] = 1; image[8, 53] = 1; image[8, 54] = 1; image[8, 55] = 1; image[8, 56] = 1; image[8, 57] = 1; image[8, 58] = 0; image[8, 59] = 0; image[8, 60] = 0; image[8, 61] = 1; image[8, 62] = 0; image[8, 63] = 0; image[8, 64] = 0; image[8, 65] = 0; image[8, 66] = 0; image[8, 67] = 0; image[8, 68] = 1; image[8, 69] = 0; image[8, 70] = 0; image[8, 71] = 1; image[8, 72] = 0; image[8, 73] = 0; image[8, 74] = 0; image[8, 75] = 0; image[8, 76] = 0; image[8, 77] = 0; image[8, 78] = 1; image[8, 79] = 0; image[8, 80] = 0; image[8, 81] = 1; image[8, 82] = 0; image[8, 83] = 0; image[8, 84] = 0; image[8, 85] = 0; image[8, 86] = 0; image[8, 87] = 0; image[8, 88] = 1; image[8, 89] = 0; image[8, 90] = 0; image[8, 91] = 0; image[8, 92] = 1; image[8, 93] = 1; image[8, 94] = 1; image[8, 95] = 1; image[8, 96] = 1; image[8, 97] = 1; image[8, 98] = 0; image[8, 99] = 0;
            image[9, 0] = 0; image[9, 1] = 0; image[9, 2] = 1; image[9, 3] = 1; image[9, 4] = 1; image[9, 5] = 1; image[9, 6] = 1; image[9, 7] = 1; image[9, 8] = 0; image[9, 9] = 0; image[9, 10] = 0; image[9, 11] = 1; image[9, 12] = 0; image[9, 13] = 0; image[9, 14] = 0; image[9, 15] = 0; image[9, 16] = 0; image[9, 17] = 0; image[9, 18] = 1; image[9, 19] = 0; image[9, 20] = 0; image[9, 21] = 1; image[9, 22] = 0; image[9, 23] = 0; image[9, 24] = 0; image[9, 25] = 0; image[9, 26] = 0; image[9, 27] = 0; image[9, 28] = 1; image[9, 29] = 0; image[9, 30] = 0; image[9, 31] = 1; image[9, 32] = 0; image[9, 33] = 0; image[9, 34] = 0; image[9, 35] = 0; image[9, 36] = 0; image[9, 37] = 0; image[9, 38] = 1; image[9, 39] = 0; image[9, 40] = 0; image[9, 41] = 1; image[9, 42] = 0; image[9, 43] = 0; image[9, 44] = 0; image[9, 45] = 0; image[9, 46] = 0; image[9, 47] = 0; image[9, 48] = 1; image[9, 49] = 0; image[9, 50] = 0; image[9, 51] = 0; image[9, 52] = 1; image[9, 53] = 1; image[9, 54] = 1; image[9, 55] = 1; image[9, 56] = 1; image[9, 57] = 1; image[9, 58] = 0; image[9, 59] = 0; image[9, 60] = 0; image[9, 61] = 0; image[9, 62] = 0; image[9, 63] = 0; image[9, 64] = 0; image[9, 65] = 0; image[9, 66] = 0; image[9, 67] = 0; image[9, 68] = 1; image[9, 69] = 0; image[9, 70] = 0; image[9, 71] = 0; image[9, 72] = 0; image[9, 73] = 0; image[9, 74] = 0; image[9, 75] = 0; image[9, 76] = 0; image[9, 77] = 0; image[9, 78] = 1; image[9, 79] = 0; image[9, 80] = 0; image[9, 81] = 1; image[9, 82] = 0; image[9, 83] = 0; image[9, 84] = 0; image[9, 85] = 0; image[9, 86] = 0; image[9, 87] = 0; image[9, 88] = 1; image[9, 89] = 0; image[9, 90] = 0; image[9, 91] = 0; image[9, 92] = 1; image[9, 93] = 1; image[9, 94] = 1; image[9, 95] = 1; image[9, 96] = 1; image[9, 97] = 1; image[9, 98] = 0; image[9, 99] = 0;
            #endregion

            #region init_output
            output[0, 0] = 1;
            output[0, 1] = 0;
            output[0, 2] = 0;
            output[0, 3] = 0;
            output[0, 4] = 0;
            output[0, 5] = 0;
            output[0, 6] = 0;
            output[0, 7] = 0;
            output[0, 8] = 0;
            output[0, 9] = 0;

            output[1, 0] = 0;
            output[1, 1] = 1;
            output[1, 2] = 0;
            output[1, 3] = 0;
            output[1, 4] = 0;
            output[1, 5] = 0;
            output[1, 6] = 0;
            output[1, 7] = 0;
            output[1, 8] = 0;
            output[1, 9] = 0;

            output[2, 0] = 0;
            output[2, 1] = 0;
            output[2, 2] = 1;
            output[2, 3] = 0;
            output[2, 4] = 0;
            output[2, 5] = 0;
            output[2, 6] = 0;
            output[2, 7] = 0;
            output[2, 8] = 0;
            output[2, 9] = 0;

            output[3, 0] = 0;
            output[3, 1] = 0;
            output[3, 2] = 0;
            output[3, 3] = 1;
            output[3, 4] = 0;
            output[3, 5] = 0;
            output[3, 6] = 0;
            output[3, 7] = 0;
            output[3, 8] = 0;
            output[3, 9] = 0;

            output[4, 0] = 0;
            output[4, 1] = 0;
            output[4, 2] = 0;
            output[4, 3] = 0;
            output[4, 4] = 1;
            output[4, 5] = 0;
            output[4, 6] = 0;
            output[4, 7] = 0;
            output[4, 8] = 0;
            output[4, 9] = 0;

            output[5, 0] = 0;
            output[5, 1] = 0;
            output[5, 2] = 0;
            output[5, 3] = 0;
            output[5, 4] = 0;
            output[5, 5] = 1;
            output[5, 6] = 0;
            output[5, 7] = 0;
            output[5, 8] = 0;
            output[5, 9] = 0;

            output[6, 0] = 0;
            output[6, 1] = 0;
            output[6, 2] = 0;
            output[6, 3] = 0;
            output[6, 4] = 0;
            output[6, 5] = 0;
            output[6, 6] = 1;
            output[6, 7] = 0;
            output[6, 8] = 0;
            output[6, 9] = 0;

            output[7, 0] = 0;
            output[7, 1] = 0;
            output[7, 2] = 0;
            output[7, 3] = 0;
            output[7, 4] = 0;
            output[7, 5] = 0;
            output[7, 6] = 0;
            output[7, 7] = 1;
            output[7, 8] = 0;
            output[7, 9] = 0;

            output[8, 0] = 0;
            output[8, 1] = 0;
            output[8, 2] = 0;
            output[8, 3] = 0;
            output[8, 4] = 0;
            output[8, 5] = 0;
            output[8, 6] = 0;
            output[8, 7] = 0;
            output[8, 8] = 1;
            output[8, 9] = 0;

            output[9, 0] = 0;
            output[9, 1] = 0;
            output[9, 2] = 0;
            output[9, 3] = 0;
            output[9, 4] = 0;
            output[9, 5] = 0;
            output[9, 6] = 0;
            output[9, 7] = 0;
            output[9, 8] = 0;
            output[9, 9] = 1;

            #endregion

            #region buttons

            grid[0, 0] = button1;
            grid[0, 1] = button2;
            grid[0, 2] = button3;
            grid[0, 3] = button4;
            grid[0, 4] = button5;
            grid[0, 5] = button10;
            grid[0, 6] = button9;
            grid[0, 7] = button8;
            grid[0, 8] = button7;
            grid[0, 9] = button6;
            grid[1, 0] = button20;
            grid[1, 1] = button19;
            grid[1, 2] = button18;
            grid[1, 3] = button17;
            grid[1, 4] = button16;
            grid[1, 5] = button15;
            grid[1, 6] = button14;
            grid[1, 7] = button13;
            grid[1, 8] = button12;
            grid[1, 9] = button11;
            grid[2, 0] = button30;
            grid[2, 1] = button29;
            grid[2, 2] = button28;
            grid[2, 3] = button27;
            grid[2, 4] = button26;
            grid[2, 5] = button25;
            grid[2, 6] = button24;
            grid[2, 7] = button23;
            grid[2, 8] = button22;
            grid[2, 9] = button21;
            grid[3, 0] = button40;
            grid[3, 1] = button39;
            grid[3, 2] = button38;
            grid[3, 3] = button37;
            grid[3, 4] = button36;
            grid[3, 5] = button35;
            grid[3, 6] = button34;
            grid[3, 7] = button33;
            grid[3, 8] = button32;
            grid[3, 9] = button31;
            grid[4, 0] = button50;
            grid[4, 1] = button49;
            grid[4, 2] = button48;
            grid[4, 3] = button47;
            grid[4, 4] = button46;
            grid[4, 5] = button45;
            grid[4, 6] = button44;
            grid[4, 7] = button43;
            grid[4, 8] = button42;
            grid[4, 9] = button41;
            grid[5, 0] = button100;
            grid[5, 1] = button99;
            grid[5, 2] = button98;
            grid[5, 3] = button97;
            grid[5, 4] = button96;
            grid[5, 5] = button95;
            grid[5, 6] = button94;
            grid[5, 7] = button93;
            grid[5, 8] = button92;
            grid[5, 9] = button91;
            grid[6, 0] = button90;
            grid[6, 1] = button89;
            grid[6, 2] = button88;
            grid[6, 3] = button87;
            grid[6, 4] = button86;
            grid[6, 5] = button85;
            grid[6, 6] = button84;
            grid[6, 7] = button83;
            grid[6, 8] = button82;
            grid[6, 9] = button81;
            grid[7, 0] = button80;
            grid[7, 1] = button79;
            grid[7, 2] = button78;
            grid[7, 3] = button77;
            grid[7, 4] = button76;
            grid[7, 5] = button75;
            grid[7, 6] = button74;
            grid[7, 7] = button73;
            grid[7, 8] = button72;
            grid[7, 9] = button71;
            grid[8, 0] = button70;
            grid[8, 1] = button69;
            grid[8, 2] = button68;
            grid[8, 3] = button67;
            grid[8, 4] = button66;
            grid[8, 5] = button65;
            grid[8, 6] = button64;
            grid[8, 7] = button63;
            grid[8, 8] = button62;
            grid[8, 9] = button61;
            grid[9, 0] = button60;
            grid[9, 1] = button59;
            grid[9, 2] = button58;
            grid[9, 3] = button57;
            grid[9, 4] = button56;
            grid[9, 5] = button55;
            grid[9, 6] = button54;
            grid[9, 7] = button53;
            grid[9, 8] = button52;
            grid[9, 9] = button51;

            #endregion
        }


        public void generateMap()
        {
            int z = 0;

            map = new int[100];


            for (int i = 0; i < 100; i++)
            {
                map[i] = 0;
            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (grid[i, j].BackColor == Color.CornflowerBlue)
                    {
                        map[z] = 1;
                    }
                    else
                    {
                        map[z] = 0;
                    }
                    z++;
                }

            }
        }

        void initNetwork()
        {
            int i, j;

            Random rand = new Random();

            inputs[inputNeurons] = 1.0;
            hidden[hiddenNeurons] = 1.0;

            for (j = 0; j < hiddenNeurons; j++)
            {
                for (i = 0; i < inputNeurons + 1; i++)
                {
                    w_h_i[j, i] = (rand.NextDouble() - 0.5);
                }
            }

            for (j = 0; j < outputNeurons; j++)
            {
                for (i = 0; i < hiddenNeurons + 1; i++)
                {
                    w_o_h[j, i] = (rand.NextDouble() - 0.5);
                }
            }
        }


        void feedForward()
        {
            int i, j;

            for (i = 0; i < hiddenNeurons; i++)
            {
                hidden[i] = 0.0;

                for (j = 0; j < inputNeurons + 1; j++)
                {
                    hidden[i] += (w_h_i[i, j] * inputs[j]);
                }
                hidden[i] = sigmoid(hidden[i]);
            }


            for (i = 0; i < outputNeurons; i++)
            {
                outputs[i] = 0.0;

                for (j = 0; j < hiddenNeurons + 1; j++)
                {
                    outputs[i] += (w_o_h[i, j] * hidden[j]);
                }
                outputs[i] = sigmoid(outputs[i]);
            }
        }


        void backpropagateError(int test)
        {
            int outE;
            int hidE;
            int inpE;
            double[] errOut = new double[outputNeurons];
            double[] errHid = new double[hiddenNeurons];

            for (outE = 0; outE < outputNeurons; outE++)
            {
                errOut[outE] = ((double)output[test, outE] - outputs[outE]) * sigmoid_d(outputs[outE]);
            }

            for (hidE = 0; hidE < hiddenNeurons; hidE++)
            {
                errHid[hidE] = 0.0;

                for (outE = 0; outE < outputNeurons; outE++)
                {
                    errHid[hidE] += errOut[outE] * w_o_h[outE, hidE];
                }
                errHid[hidE] *= sigmoid_d(hidden[hidE]);
            }

            for (outE = 0; outE < outputNeurons; outE++)
            {
                for (hidE = 0; hidE < hiddenNeurons; hidE++)
                {
                    w_o_h[outE, hidE] += RO * errOut[outE] * hidden[hidE];
                }
            }

            for (hidE = 0; hidE < hiddenNeurons; hidE++)
            {
                for (inpE = 0; inpE < inputNeurons + 1; inpE++)
                {
                    w_h_i[hidE, inpE] += RO * errHid[hidE] * inputs[inpE];
                }
            }
        }


        double calculateMSE(int test)
        {
            double mse = 0.0;
            int i;

            for (i = 0; i < outputNeurons; i++)
            {
                mse += sqr(output[test, i] - outputs[i]);
            }

            return (mse / (double)i);
        }


        void setNetworkInputsPattern()
        {
            Random rand = new Random();

            for (int i = 0; i < inputNeurons; i++)
            {
                inputs[i] = map[i];
            }
        }


        void setNetworkInputs(int test, double noise)
        {
            Random rand = new Random();

            for (int i = 0; i < inputNeurons; i++)
            {
                inputs[i] = image[test, i];

                double randomProbability = rand.NextDouble();

                if (randomProbability < noise)
                {
                    inputs[i] = (inputs[i] == 0) ? 0 : 1;
                }
            }
        }


        int classifier()
        {
            int best = 0;
            double max;

            max = outputs[0];

            for (int i = 1; i < outputNeurons; i++)
            {
                if (outputs[i] > max)
                {
                    max = outputs[i];
                    best = i;
                }
            }
            return best;
        }

        double sigmoid(double x)
        {
            return (1.0 / (1.0 + Math.Exp(-x)));
        }

        double sigmoid_d(double x)
        {
            return (x * (1.0 - x));
        }

        double sqr(double x)
        {
            return x * x;
        }

        public void tabStop()
        {
            #region tabstop

            button1.TabStop = false;
            button2.TabStop = false;
            button3.TabStop = false;
            button4.TabStop = false;
            button5.TabStop = false;
            button6.TabStop = false;
            button7.TabStop = false;
            button8.TabStop = false;
            button9.TabStop = false;
            button10.TabStop = false;
            button11.TabStop = false;
            button12.TabStop = false;
            button13.TabStop = false;
            button14.TabStop = false;
            button15.TabStop = false;
            button16.TabStop = false;
            button17.TabStop = false;
            button18.TabStop = false;
            button19.TabStop = false;
            button20.TabStop = false;
            button21.TabStop = false;
            button22.TabStop = false;
            button23.TabStop = false;
            button24.TabStop = false;
            button25.TabStop = false;
            button26.TabStop = false;
            button27.TabStop = false;
            button28.TabStop = false;
            button29.TabStop = false;
            button30.TabStop = false;
            button31.TabStop = false;
            button32.TabStop = false;
            button33.TabStop = false;
            button34.TabStop = false;
            button35.TabStop = false;
            button36.TabStop = false;
            button37.TabStop = false;
            button38.TabStop = false;
            button39.TabStop = false;
            button40.TabStop = false;
            button41.TabStop = false;
            button42.TabStop = false;
            button43.TabStop = false;
            button44.TabStop = false;
            button45.TabStop = false;
            button46.TabStop = false;
            button47.TabStop = false;
            button48.TabStop = false;
            button49.TabStop = false;
            button50.TabStop = false;
            button51.TabStop = false;
            button52.TabStop = false;
            button53.TabStop = false;
            button54.TabStop = false;
            button55.TabStop = false;
            button56.TabStop = false;
            button57.TabStop = false;
            button58.TabStop = false;
            button59.TabStop = false;
            button60.TabStop = false;
            button61.TabStop = false;
            button62.TabStop = false;
            button63.TabStop = false;
            button64.TabStop = false;
            button65.TabStop = false;
            button66.TabStop = false;
            button67.TabStop = false;
            button68.TabStop = false;
            button69.TabStop = false;
            button70.TabStop = false;
            button71.TabStop = false;
            button72.TabStop = false;
            button73.TabStop = false;
            button74.TabStop = false;
            button75.TabStop = false;
            button76.TabStop = false;
            button77.TabStop = false;
            button78.TabStop = false;
            button79.TabStop = false;
            button80.TabStop = false;
            button81.TabStop = false;
            button82.TabStop = false;
            button83.TabStop = false;
            button84.TabStop = false;
            button85.TabStop = false;
            button86.TabStop = false;
            button87.TabStop = false;
            button88.TabStop = false;
            button89.TabStop = false;
            button90.TabStop = false;
            button91.TabStop = false;
            button92.TabStop = false;
            button93.TabStop = false;
            button94.TabStop = false;
            button95.TabStop = false;
            button96.TabStop = false;
            button97.TabStop = false;
            button98.TabStop = false;
            button99.TabStop = false;
            button100.TabStop = false;

            #endregion
        }

        public void resetGrid()
        {
            label1.Text = "X";

            #region reset

            button1.BackColor = Color.FromArgb(224, 224, 224);
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button4.BackColor = Color.FromArgb(224, 224, 224);
            button5.BackColor = Color.FromArgb(224, 224, 224);
            button6.BackColor = Color.FromArgb(224, 224, 224);
            button7.BackColor = Color.FromArgb(224, 224, 224);
            button8.BackColor = Color.FromArgb(224, 224, 224);
            button9.BackColor = Color.FromArgb(224, 224, 224);
            button10.BackColor = Color.FromArgb(224, 224, 224);
            button11.BackColor = Color.FromArgb(224, 224, 224);
            button12.BackColor = Color.FromArgb(224, 224, 224);
            button13.BackColor = Color.FromArgb(224, 224, 224);
            button14.BackColor = Color.FromArgb(224, 224, 224);
            button15.BackColor = Color.FromArgb(224, 224, 224);
            button16.BackColor = Color.FromArgb(224, 224, 224);
            button17.BackColor = Color.FromArgb(224, 224, 224);
            button18.BackColor = Color.FromArgb(224, 224, 224);
            button19.BackColor = Color.FromArgb(224, 224, 224);
            button20.BackColor = Color.FromArgb(224, 224, 224);
            button21.BackColor = Color.FromArgb(224, 224, 224);
            button22.BackColor = Color.FromArgb(224, 224, 224);
            button23.BackColor = Color.FromArgb(224, 224, 224);
            button24.BackColor = Color.FromArgb(224, 224, 224);
            button25.BackColor = Color.FromArgb(224, 224, 224);
            button26.BackColor = Color.FromArgb(224, 224, 224);
            button27.BackColor = Color.FromArgb(224, 224, 224);
            button28.BackColor = Color.FromArgb(224, 224, 224);
            button29.BackColor = Color.FromArgb(224, 224, 224);
            button30.BackColor = Color.FromArgb(224, 224, 224);
            button31.BackColor = Color.FromArgb(224, 224, 224);
            button32.BackColor = Color.FromArgb(224, 224, 224);
            button33.BackColor = Color.FromArgb(224, 224, 224);
            button34.BackColor = Color.FromArgb(224, 224, 224);
            button35.BackColor = Color.FromArgb(224, 224, 224);
            button36.BackColor = Color.FromArgb(224, 224, 224);
            button37.BackColor = Color.FromArgb(224, 224, 224);
            button38.BackColor = Color.FromArgb(224, 224, 224);
            button39.BackColor = Color.FromArgb(224, 224, 224);
            button40.BackColor = Color.FromArgb(224, 224, 224);
            button41.BackColor = Color.FromArgb(224, 224, 224);
            button42.BackColor = Color.FromArgb(224, 224, 224);
            button43.BackColor = Color.FromArgb(224, 224, 224);
            button44.BackColor = Color.FromArgb(224, 224, 224);
            button45.BackColor = Color.FromArgb(224, 224, 224);
            button46.BackColor = Color.FromArgb(224, 224, 224);
            button47.BackColor = Color.FromArgb(224, 224, 224);
            button48.BackColor = Color.FromArgb(224, 224, 224);
            button49.BackColor = Color.FromArgb(224, 224, 224);
            button50.BackColor = Color.FromArgb(224, 224, 224);
            button51.BackColor = Color.FromArgb(224, 224, 224);
            button52.BackColor = Color.FromArgb(224, 224, 224);
            button53.BackColor = Color.FromArgb(224, 224, 224);
            button54.BackColor = Color.FromArgb(224, 224, 224);
            button55.BackColor = Color.FromArgb(224, 224, 224);
            button56.BackColor = Color.FromArgb(224, 224, 224);
            button57.BackColor = Color.FromArgb(224, 224, 224);
            button58.BackColor = Color.FromArgb(224, 224, 224);
            button59.BackColor = Color.FromArgb(224, 224, 224);
            button60.BackColor = Color.FromArgb(224, 224, 224);
            button61.BackColor = Color.FromArgb(224, 224, 224);
            button62.BackColor = Color.FromArgb(224, 224, 224);
            button63.BackColor = Color.FromArgb(224, 224, 224);
            button64.BackColor = Color.FromArgb(224, 224, 224);
            button65.BackColor = Color.FromArgb(224, 224, 224);
            button66.BackColor = Color.FromArgb(224, 224, 224);
            button67.BackColor = Color.FromArgb(224, 224, 224);
            button68.BackColor = Color.FromArgb(224, 224, 224);
            button69.BackColor = Color.FromArgb(224, 224, 224);
            button70.BackColor = Color.FromArgb(224, 224, 224);
            button71.BackColor = Color.FromArgb(224, 224, 224);
            button72.BackColor = Color.FromArgb(224, 224, 224);
            button73.BackColor = Color.FromArgb(224, 224, 224);
            button74.BackColor = Color.FromArgb(224, 224, 224);
            button75.BackColor = Color.FromArgb(224, 224, 224);
            button76.BackColor = Color.FromArgb(224, 224, 224);
            button77.BackColor = Color.FromArgb(224, 224, 224);
            button78.BackColor = Color.FromArgb(224, 224, 224);
            button79.BackColor = Color.FromArgb(224, 224, 224);
            button80.BackColor = Color.FromArgb(224, 224, 224);
            button81.BackColor = Color.FromArgb(224, 224, 224);
            button82.BackColor = Color.FromArgb(224, 224, 224);
            button83.BackColor = Color.FromArgb(224, 224, 224);
            button84.BackColor = Color.FromArgb(224, 224, 224);
            button85.BackColor = Color.FromArgb(224, 224, 224);
            button86.BackColor = Color.FromArgb(224, 224, 224);
            button87.BackColor = Color.FromArgb(224, 224, 224);
            button88.BackColor = Color.FromArgb(224, 224, 224);
            button89.BackColor = Color.FromArgb(224, 224, 224);
            button90.BackColor = Color.FromArgb(224, 224, 224);
            button91.BackColor = Color.FromArgb(224, 224, 224);
            button92.BackColor = Color.FromArgb(224, 224, 224);
            button93.BackColor = Color.FromArgb(224, 224, 224);
            button94.BackColor = Color.FromArgb(224, 224, 224);
            button95.BackColor = Color.FromArgb(224, 224, 224);
            button96.BackColor = Color.FromArgb(224, 224, 224);
            button97.BackColor = Color.FromArgb(224, 224, 224);
            button98.BackColor = Color.FromArgb(224, 224, 224);
            button99.BackColor = Color.FromArgb(224, 224, 224);
            button100.BackColor = Color.FromArgb(224, 224, 224);

            #endregion
            tabStop();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(224, 224, 224))
            {
                button1.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button1.BackColor = Color.FromArgb(224, 224, 224);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            resetGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(224, 224, 224))
            {
                button2.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button2.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(224, 224, 224))
            {
                button3.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button3.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.FromArgb(224, 224, 224))
            {
                button4.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button4.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.FromArgb(224, 224, 224))
            {
                button5.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button5.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.FromArgb(224, 224, 224))
            {
                button10.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button10.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.FromArgb(224, 224, 224))
            {
                button9.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button9.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.FromArgb(224, 224, 224))
            {
                button8.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button8.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.FromArgb(224, 224, 224))
            {
                button7.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button7.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.FromArgb(224, 224, 224))
            {
                button6.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button6.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.FromArgb(224, 224, 224))
            {
                button11.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button11.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.BackColor == Color.FromArgb(224, 224, 224))
            {
                button12.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button12.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor == Color.FromArgb(224, 224, 224))
            {
                button13.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button13.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.FromArgb(224, 224, 224))
            {
                button14.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button14.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.BackColor == Color.FromArgb(224, 224, 224))
            {
                button15.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button15.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.BackColor == Color.FromArgb(224, 224, 224))
            {
                button16.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button16.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.BackColor == Color.FromArgb(224, 224, 224))
            {
                button17.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button17.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.BackColor == Color.FromArgb(224, 224, 224))
            {
                button18.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button18.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.BackColor == Color.FromArgb(224, 224, 224))
            {
                button19.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button19.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.BackColor == Color.FromArgb(224, 224, 224))
            {
                button20.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button20.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (button30.BackColor == Color.FromArgb(224, 224, 224))
            {
                button30.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button30.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.BackColor == Color.FromArgb(224, 224, 224))
            {
                button29.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button29.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (button28.BackColor == Color.FromArgb(224, 224, 224))
            {
                button28.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button28.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.BackColor == Color.FromArgb(224, 224, 224))
            {
                button27.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button27.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.BackColor == Color.FromArgb(224, 224, 224))
            {
                button26.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button26.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.BackColor == Color.FromArgb(224, 224, 224))
            {
                button25.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button25.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (button24.BackColor == Color.FromArgb(224, 224, 224))
            {
                button24.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button24.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.BackColor == Color.FromArgb(224, 224, 224))
            {
                button23.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button23.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (button22.BackColor == Color.FromArgb(224, 224, 224))
            {
                button22.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button22.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.BackColor == Color.FromArgb(224, 224, 224))
            {
                button21.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button21.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.BackColor == Color.FromArgb(224, 224, 224))
            {
                button31.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button31.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (button32.BackColor == Color.FromArgb(224, 224, 224))
            {
                button32.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button32.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.BackColor == Color.FromArgb(224, 224, 224))
            {
                button33.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button33.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (button34.BackColor == Color.FromArgb(224, 224, 224))
            {
                button34.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button34.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (button35.BackColor == Color.FromArgb(224, 224, 224))
            {
                button35.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button35.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (button36.BackColor == Color.FromArgb(224, 224, 224))
            {
                button36.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button36.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.BackColor == Color.FromArgb(224, 224, 224))
            {
                button37.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button37.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (button38.BackColor == Color.FromArgb(224, 224, 224))
            {
                button38.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button38.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (button39.BackColor == Color.FromArgb(224, 224, 224))
            {
                button39.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button39.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (button40.BackColor == Color.FromArgb(224, 224, 224))
            {
                button40.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button40.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (button50.BackColor == Color.FromArgb(224, 224, 224))
            {
                button50.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button50.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (button49.BackColor == Color.FromArgb(224, 224, 224))
            {
                button49.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button49.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (button48.BackColor == Color.FromArgb(224, 224, 224))
            {
                button48.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button48.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (button47.BackColor == Color.FromArgb(224, 224, 224))
            {
                button47.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button47.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (button46.BackColor == Color.FromArgb(224, 224, 224))
            {
                button46.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button46.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.BackColor == Color.FromArgb(224, 224, 224))
            {
                button45.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button45.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (button44.BackColor == Color.FromArgb(224, 224, 224))
            {
                button44.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button44.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (button43.BackColor == Color.FromArgb(224, 224, 224))
            {
                button43.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button43.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (button42.BackColor == Color.FromArgb(224, 224, 224))
            {
                button42.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button42.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.BackColor == Color.FromArgb(224, 224, 224))
            {
                button41.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button41.BackColor = Color.FromArgb(224, 224, 224);
            }
         
        }

        private void button91_Click(object sender, EventArgs e)
        {
            if (button91.BackColor == Color.FromArgb(224, 224, 224))
            {
                button91.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button91.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button92_Click(object sender, EventArgs e)
        {
            if (button92.BackColor == Color.FromArgb(224, 224, 224))
            {
                button92.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button92.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if (button93.BackColor == Color.FromArgb(224, 224, 224))
            {
                button93.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button93.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (button94.BackColor == Color.FromArgb(224, 224, 224))
            {
                button94.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button94.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button95_Click(object sender, EventArgs e)
        {
            if (button95.BackColor == Color.FromArgb(224, 224, 224))
            {
                button95.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button95.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (button96.BackColor == Color.FromArgb(224, 224, 224))
            {
                button96.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button96.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button97_Click(object sender, EventArgs e)
        {
            if (button97.BackColor == Color.FromArgb(224, 224, 224))
            {
                button97.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button97.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button98_Click(object sender, EventArgs e)
        {
            if (button98.BackColor == Color.FromArgb(224, 224, 224))
            {
                button98.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button98.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button99_Click(object sender, EventArgs e)
        {
            if (button99.BackColor == Color.FromArgb(224, 224, 224))
            {
                button99.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button99.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button100_Click(object sender, EventArgs e)
        {
            if (button100.BackColor == Color.FromArgb(224, 224, 224))
            {
                button100.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button100.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button90_Click(object sender, EventArgs e)
        {
            if (button90.BackColor == Color.FromArgb(224, 224, 224))
            {
                button90.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button90.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button89_Click(object sender, EventArgs e)
        {
            if (button89.BackColor == Color.FromArgb(224, 224, 224))
            {
                button89.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button89.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button88_Click(object sender, EventArgs e)
        {
            if (button88.BackColor == Color.FromArgb(224, 224, 224))
            {
                button88.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button88.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button87_Click(object sender, EventArgs e)
        {
            if (button87.BackColor == Color.FromArgb(224, 224, 224))
            {
                button87.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button87.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button86_Click(object sender, EventArgs e)
        {
            if (button86.BackColor == Color.FromArgb(224, 224, 224))
            {
                button86.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button86.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button85_Click(object sender, EventArgs e)
        {
            if (button85.BackColor == Color.FromArgb(224, 224, 224))
            {
                button85.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button85.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button84_Click(object sender, EventArgs e)
        {
            if (button84.BackColor == Color.FromArgb(224, 224, 224))
            {
                button84.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button84.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button83_Click(object sender, EventArgs e)
        {
            if (button83.BackColor == Color.FromArgb(224, 224, 224))
            {
                button83.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button83.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button82_Click(object sender, EventArgs e)
        {
            if (button82.BackColor == Color.FromArgb(224, 224, 224))
            {
                button82.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button82.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button81_Click(object sender, EventArgs e)
        {
            if (button81.BackColor == Color.FromArgb(224, 224, 224))
            {
                button81.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button81.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button71_Click(object sender, EventArgs e)
        {
            if (button71.BackColor == Color.FromArgb(224, 224, 224))
            {
                button71.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button71.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button72_Click(object sender, EventArgs e)
        {
            if (button72.BackColor == Color.FromArgb(224, 224, 224))
            {
                button72.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button72.BackColor = Color.FromArgb(224, 224, 224);
            }
         
        }

        private void button73_Click(object sender, EventArgs e)
        {
            if (button73.BackColor == Color.FromArgb(224, 224, 224))
            {
                button73.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button73.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button74_Click(object sender, EventArgs e)
        {
            if (button74.BackColor == Color.FromArgb(224, 224, 224))
            {
                button74.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button74.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button75_Click(object sender, EventArgs e)
        {
            if (button75.BackColor == Color.FromArgb(224, 224, 224))
            {
                button75.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button75.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button76_Click(object sender, EventArgs e)
        {
            if (button76.BackColor == Color.FromArgb(224, 224, 224))
            {
                button76.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button76.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button77_Click(object sender, EventArgs e)
        {
            if (button77.BackColor == Color.FromArgb(224, 224, 224))
            {
                button77.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button77.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button78_Click(object sender, EventArgs e)
        {
            if (button78.BackColor == Color.FromArgb(224, 224, 224))
            {
                button78.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button78.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button79_Click(object sender, EventArgs e)
        {
            if (button79.BackColor == Color.FromArgb(224, 224, 224))
            {
                button79.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button79.BackColor = Color.FromArgb(224, 224, 224);
            }
         
        }

        private void button80_Click(object sender, EventArgs e)
        {
            if (button80.BackColor == Color.FromArgb(224, 224, 224))
            {
                button80.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button80.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button70_Click(object sender, EventArgs e)
        {
            if (button70.BackColor == Color.FromArgb(224, 224, 224))
            {
                button70.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button70.BackColor = Color.FromArgb(224, 224, 224);
            }
        
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (button69.BackColor == Color.FromArgb(224, 224, 224))
            {
                button69.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button69.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (button68.BackColor == Color.FromArgb(224, 224, 224))
            {
                button68.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button68.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (button67.BackColor == Color.FromArgb(224, 224, 224))
            {
                button67.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button67.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (button66.BackColor == Color.FromArgb(224, 224, 224))
            {
                button66.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button66.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button65_Click(object sender, EventArgs e)
        {
            if (button65.BackColor == Color.FromArgb(224, 224, 224))
            {
                button65.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button65.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (button64.BackColor == Color.FromArgb(224, 224, 224))
            {
                button64.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button64.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (button63.BackColor == Color.FromArgb(224, 224, 224))
            {
                button63.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button63.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (button62.BackColor == Color.FromArgb(224, 224, 224))
            {
                button62.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button62.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (button61.BackColor == Color.FromArgb(224, 224, 224))
            {
                button61.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button61.BackColor = Color.FromArgb(224, 224, 224);
            }
            
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (button60.BackColor == Color.FromArgb(224, 224, 224))
            {
                button60.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button60.BackColor = Color.FromArgb(224, 224, 224);
            }
         
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if (button59.BackColor == Color.FromArgb(224, 224, 224))
            {
                button59.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button59.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (button58.BackColor == Color.FromArgb(224, 224, 224))
            {
                button58.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button58.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (button57.BackColor == Color.FromArgb(224, 224, 224))
            {
                button57.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button57.BackColor = Color.FromArgb(224, 224, 224);
            }
         
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (button56.BackColor == Color.FromArgb(224, 224, 224))
            {
                button56.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button56.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if (button55.BackColor == Color.FromArgb(224, 224, 224))
            {
                button55.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button55.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (button54.BackColor == Color.FromArgb(224, 224, 224))
            {
                button54.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button54.BackColor = Color.FromArgb(224, 224, 224);
            }
           
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (button53.BackColor == Color.FromArgb(224, 224, 224))
            {
                button53.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button53.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (button52.BackColor == Color.FromArgb(224, 224, 224))
            {
                button52.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button52.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (button51.BackColor == Color.FromArgb(224, 224, 224))
            {
                button51.BackColor = Color.CornflowerBlue;
            }
            else
            {
                button51.BackColor = Color.FromArgb(224, 224, 224);
            }
          
        }

        private void button101_Click(object sender, EventArgs e)
        {
            Random randTrain = new Random();

            double mse;
            int test;
            int zero = 0;

            generateMap();
            initNetwork();

            do
            {
                test = randTrain.Next(0, 10);

                setNetworkInputs(test, 0.0);
                feedForward();
                backpropagateError(test);
                mse = calculateMSE(test);

            } while (mse > 0.001);

            setNetworkInputsPattern();
            feedForward();

            for (int z = 0; z < inputNeurons; z++)
            {
                zero += map[z];
            }

            if (zero > 0)
            {
                label1.Text = classifier().ToString();
            }
            else
            {
                label1.Text = "X";
            }
        }
    }
}
