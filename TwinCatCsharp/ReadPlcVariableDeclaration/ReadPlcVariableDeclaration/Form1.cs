/*
 * PLC program

PROGRAM MAIN
VAR
        REAL32_1 AT %MB0 : REAL;  (* 1 *)
        REAL32_2 AT %MB4 : REAL;  (* 2 *)
        REAL32_3 AT %MB8 : REAL;  (* 3 *)
        REAL32_4 AT %MB12: REAL;  (* 4 *)
        REAL32_5 AT %MB16: REAL;  (* 5 *)

        REAL64_1 AT %MB20 : LREAL;  (* 6 *)
        REAL64_2 AT %MB28 : LREAL;  (* 7 *)
        REAL64_3 AT %MB36 : LREAL;  (* 8 *)
        REAL64_4 AT %MB44 : LREAL;  (* 9 *)
        REAL64_5 AT %MB52 : LREAL;  (* 10 *)

        INT32_1 AT %MB60 : DINT;  (* 11 *)
        INT32_2 AT %MB64 : DINT;  (* 12 *)
        INT32_3 AT %MB68 : DINT;  (* 13 *)
        INT32_4 AT %MB72 : DINT;  (* 14 *)
        INT32_5 AT %MB76 : DINT;  (* 15 *)

        UINT32_1 AT %MB80 : UDINT;  (* 16 *)
        UINT32_2 AT %MB84 : UDINT;  (* 17 *)
        UINT32_3 AT %MB88 : UDINT;  (* 18 *)
        UINT32_4 AT %MB92 : UDINT;  (* 19 *)
        UINT32_5 AT %MB96 : UDINT;  (* 20 *)

        INT16_1 AT %MB100 : INT;  (* 21 *)
        INT16_2 AT %MB102 : INT;  (* 22 *)
        INT16_3 AT %MB104 : INT;  (* 23 *)
        INT16_4 AT %MB106 : INT;  (* 24 *)
        INT16_5 AT %MB108 : INT;  (* 25 *)

        UINT16_1 AT %MB110 : UINT;  (* 26 *)
        UINT16_2 AT %MB112 : UINT;  (* 27 *)
        UINT16_3 AT %MB114 : UINT;  (* 28 *)
        UINT16_4 AT %MB116 : UINT;  (* 29 *)
        UINT16_5 AT %MB118 : UINT;  (* 30 *)

        INT8_1 AT %MB120 : SINT;  (* 31 *)
        INT8_2 AT %MB121 : SINT;  (* 32 *)
        INT8_3 AT %MB122 : SINT;  (* 33 *)
        INT8_4 AT %MB123 : SINT;  (* 34 *)
        INT8_5 AT %MB124 : SINT;  (* 35 *)

        UINT8_1 AT %MB125 : USINT;  (* 36 *)
        UINT8_2 AT %MB126 : USINT;  (* 37 *)
        UINT8_3 AT %MB128 : USINT;  (* 38 *)
        UINT8_4 AT %MB129 : USINT;  (* 39 *)
        UINT8_5 AT %MB130 : USINT;  (* 40 *)

        BOOL_1 AT %MX131.0 : BOOL;  (* 41 *)
        BOOL_2 AT %MX131.1 : BOOL;  (* 42 *)
        BOOL_3 AT %MX131.2 : BOOL;  (* 43 *)
        BOOL_4 AT %MX131.3 : BOOL;  (* 44 *)
        BOOL_5 AT %MX131.4 : BOOL;  (* 45 *)

        ARRAY_1 : ARRAY[1 .. 10] OF SINT; (* 46 *)
        ARRAY_2 : ARRAY[1 .. 10] OF INT;  (* 47 *)
        ARRAY_3 : ARRAY[1 .. 10] OF DINT; (* 48 *)
        ARRAY_4 : ARRAY[1 .. 10] OF LREAL;(* 49 *)
        ARRAY_5 : ARRAY[1 .. 10] OF BOOL; (* 50 *)

        STRING_1 : STRING(20);
END_VAR

https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
            
      Note: Doc tat ca bien duoc khai bao trong PLC
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;
using TwinCAT;
using TwinCAT.Ads;

namespace ReadPlcVariableDeclaration
{
    public partial class Form1 : Form
    {
        private TcAdsSymbolInfoLoader symbolLoader;
        private TcAdsClient adsClient;
        private ITcAdsSymbol currentSymbol = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                adsClient = new TcAdsClient();
                adsClient.Connect(851);
                symbolLoader = adsClient.CreateSymbolInfoLoader();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            treeViewSymbols.Nodes.Clear();
            try
            {
                if (!cbFlat.Checked)
                {
                    TcAdsSymbolInfo symbol = symbolLoader.GetFirstSymbol(true);
                    while (symbol != null)
                    {
                        treeViewSymbols.Nodes.Add(CreateNewNode(symbol));
                        symbol = symbol.NextSymbol;
                    }
                }
                else
                {
                    foreach (TcAdsSymbolInfo symbol in symbolLoader)
                    {
                        TreeNode node = new TreeNode(symbol.Name);
                        node.Tag = symbol;
                        treeViewSymbols.Nodes.Add(node);
                    }
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnReadSymbolInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ITcAdsSymbol symbol = adsClient.ReadSymbolInfo(tbSymbolname.Text);
                if (symbol == null)
                {
                    Debug.WriteLine("Symbol " + tbSymbolname.Text + " not found");
                    return;
                }
                SetSymbolInfo(symbol);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnFindSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                ITcAdsSymbol symbol = symbolLoader.FindSymbol(tbSymbolname.Text);
                if (symbol == null)
                {
                    Debug.WriteLine("Symbol " + tbSymbolname.Text + " not found");
                    return;
                }
                SetSymbolInfo(symbol);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSymbol != null)
                    adsClient.WriteSymbol(currentSymbol, tbValue.Text);
            }
            catch (Exception err)
            {
                Debug.WriteLine("Unable to write Value. " + err.Message);
            }
        }

        private void treeViewSymbols_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.Length > 0)
            {
                if (e.Node.Tag is TcAdsSymbolInfo)
                {
                    SetSymbolInfo((ITcAdsSymbol)e.Node.Tag);
                }
            }
        }

        private TreeNode CreateNewNode(TcAdsSymbolInfo symbol)
        {
            TreeNode node = new TreeNode(symbol.Name);
            node.Tag = symbol;
            TcAdsSymbolInfo subSymbol = symbol.FirstSubSymbol;
            while (subSymbol != null)
            {
                node.Nodes.Add(CreateNewNode(subSymbol));
                subSymbol = subSymbol.NextSymbol;
            }
            return node;
        }

        private void SetSymbolInfo(ITcAdsSymbol symbol)
        {
            currentSymbol = symbol;
            tbName.Text = symbol.Name.ToString();
            tbIndexGroup.Text = symbol.IndexGroup.ToString();
            tbIndexOffset.Text = symbol.IndexOffset.ToString();
            tbSize.Text = symbol.Size.ToString();
            tbDatatype.Text = symbol.Type;
            tbDatatypeId.Text = symbol.Datatype.ToString();
            try
            {
                tbValue.Text = adsClient.ReadSymbol(symbol).ToString();
            }
            catch (AdsDatatypeNotSupportedException err)
            {
                tbValue.Text = err.Message;
            }
            catch (Exception err)
            {
                Debug.WriteLine("Unable to read Symbol Info. " + err.Message);
            }
        }
    }
}
