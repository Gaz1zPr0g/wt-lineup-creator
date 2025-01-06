using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;

namespace Lineups_creator
{
    class Templates
    {

        string tablePath = Properties.Settings.Default.Language == "ru" ? "config/RUS.xlsx" : "config/ENG.xlsx";

        public Dictionary<string, VehicleData> template = new Dictionary<string, VehicleData>();

        public Templates(int country)
        {
            try
            {
                IWorkbook workbook;
                using (FileStream fileStream = new FileStream(tablePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }

                ISheet sheet = workbook.GetSheetAt(country);
                int i = 1;
                IRow row;
                while (sheet.GetRow(i) != null)
                {
                    row = sheet.GetRow(i);
                    string codeName = row.GetCell(0).ToString();
                    string name = row.GetCell(1).ToString();
                    int type = Convert.ToInt32(row.GetCell(2).ToString());
                    string iconLink = row.GetCell(3).ToString();
                    int backgroundID = Convert.ToInt32(row.GetCell(4).ToString());
                    string wtID = row.GetCell(5).ToString();
                    template[codeName] = new VehicleData(name, type, iconLink, backgroundID, wtID, 0);
                    i++;
                }
            } catch
            {
                MessageBox.Show(text: "Excel table cannot be openned or processed", caption: "Error", buttons: MessageBoxButtons.OK);
            }
        }

        public string GetLinkByName(string name)
        {
            if (template.ContainsKey(name))
            {
                return template[name].imageLink;
            } else
            {
                return "https://encyclopedia.warthunder.com/i/slots/ussr_bt_5.png";
            }
        }

    }
}
