using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCAddin.UI
{
    public partial class ProjectPlanForm : Form
    {
        public ProjectPlanForm()
        {
            InitializeComponent();
        }

        private List<ProjectItem> GenerateSampleData()
        {
            var result = new List<ProjectItem>();

            var proj = new ProjectItem();

            proj.Name = "Project1";
            proj.Description = "Proj1 Description";
            proj.Start = new DateTime(2014, 9, 1);
            proj.End = new DateTime(2014, 11, 1);
            proj.Tasks = new List<TaskItem>();
            proj.Tasks.Add(new TaskItem { Subject = "Task1", StartDate = new DateTime(2014, 9, 5), DueDate = new DateTime(2014, 9, 7) });
            proj.Tasks.Add(new TaskItem { Subject = "Task2", StartDate = new DateTime(2014, 9, 7), DueDate = new DateTime(2014, 9, 9) });

            result.Add(proj);

            proj = new ProjectItem();

            proj.Name = "Project2";
            proj.Description = "Proj2 Description";
            proj.Start = new DateTime(2014, 9, 1);
            proj.End = new DateTime(2014, 11, 1);
            proj.Tasks = new List<TaskItem>();
            proj.Tasks.Add(new TaskItem { Subject = "Task1", StartDate = new DateTime(2014, 9, 10), DueDate = new DateTime(2014, 9, 15) });
            proj.Tasks.Add(new TaskItem { Subject = "Task2", StartDate = new DateTime(2014, 9, 7), DueDate = new DateTime(2014, 9, 27) });

            result.Add(proj);

            return result;
        }

        internal DateTime DateFromString(string s)
        {
            string delimStr = "//";
            char[] delimiter = delimStr.ToCharArray();
            string[] sA = s.Split(delimiter);
            return new DateTime(int.Parse(sA[2]), int.Parse(sA[0]), int.Parse(sA[1]));
        }

        private void SetupGantt2(List<ProjectItem> projects)
        {
            exg2antt1.BeginUpdate();

            exg2antt1.MarkSearchColumn = false;
            exg2antt1.ShowFocusRect = false;
            exg2antt1.OnResizeControl = exontrol.EXG2ANTTLib.OnResizeControlEnum.exResizeChart;

            //Columns Definition

            (exg2antt1.Columns.Add("Name") as exontrol.EXG2ANTTLib.Column).AllowDragging = false;

            exontrol.EXG2ANTTLib.Column var_Column = (exg2antt1.Columns.Add("Histogram") as exontrol.EXG2ANTTLib.Column);
            var_Column.AllowDragging = false;
            var_Column.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellHasCheckBox, true);
            var_Column.PartialCheck = true;
            var_Column.AllowSizing = false;
            var_Column.Width = 18;
            var_Column.LevelKey = 1;
            exg2antt1.Items.AllowCellValueToItemBar = true;

            var colStart = (exg2antt1.Columns.Add("Start") as exontrol.EXG2ANTTLib.Column);
            colStart.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellValueToItemBarProperty, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarStart);
            colStart.Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DateType;

            var colEnd = (exg2antt1.Columns.Add("End") as exontrol.EXG2ANTTLib.Column);
            colEnd.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellValueToItemBarProperty, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarEnd);
            colEnd.Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DateType;

            //var colDescription = (exg2antt1.Columns.Add("Beschreibung") as exontrol.EXG2ANTTLib.Column);
            //colDescription.AllowDragging = false;
            //colDescription.Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.MemoDropDownType;

            //var colStatus = (exg2antt1.Columns.Add("Status") as exontrol.EXG2ANTTLib.Column);
            //colStatus.AllowDragging = false;
            //var statusEditor = colStatus.Editor;
            //statusEditor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DropDownListType;

            //var colPriority = (exg2antt1.Columns.Add("Priorität") as exontrol.EXG2ANTTLib.Column);
            //colPriority.AllowDragging = false;
            //var priorityEditor = colPriority.Editor;
            //priorityEditor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DropDownListType;

            //var colComplete = (exg2antt1.Columns.Add("Fortschritt") as exontrol.EXG2ANTTLib.Column);
            //colComplete.Width = 64;
            //colComplete.AllowDragging = false;
            //var completeEditor = colComplete.Editor;
            //completeEditor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.SliderType;
            //completeEditor.set_Option(exontrol.EXG2ANTTLib.EditorOptionEnum.exSliderMax, 100);
            //completeEditor.set_Option(exontrol.EXG2ANTTLib.EditorOptionEnum.exSliderMin, 0);

            //var ownerCol = (exg2antt1.Columns.Add("Benutzer") as exontrol.EXG2ANTTLib.Column);
            //ownerCol.AllowDragging = false;
            //var ownerEditor = ownerCol.Editor;
            //ownerEditor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DropDownListType;

            //var tagsCol = (exg2antt1.Columns.Add("Tags") as exontrol.EXG2ANTTLib.Column);
            //tagsCol.AllowDragging = false;
            //var tagsEditor = tagsCol.Editor;
            //tagsEditor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.EditType;

            exontrol.EXG2ANTTLib.Column colEffort = (exg2antt1.Columns.Add("Effort") as exontrol.EXG2ANTTLib.Column);
            colEffort.LevelKey = 1;
            colEffort.AllowDragging = false;
            colEffort.AllowSizing = false;
            colEffort.Width = 64;
            colEffort.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellValueToItemBarProperty, 21);

            exontrol.EXG2ANTTLib.Editor var_Editor = colEffort.Editor;
            var_Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.SliderType;
            var_Editor.set_Option(exontrol.EXG2ANTTLib.EditorOptionEnum.exSliderWidth, -100);
            var_Editor.set_Option(exontrol.EXG2ANTTLib.EditorOptionEnum.exSliderMax, 9);
            var_Editor.set_Option(exontrol.EXG2ANTTLib.EditorOptionEnum.exSliderMin, 1);

            exontrol.EXG2ANTTLib.Chart chart = exg2antt1.Chart;
            chart.AllowOverviewZoom = exontrol.EXG2ANTTLib.OverviewZoomEnum.exAlwaysZoom;
            chart.OverviewVisible = exontrol.EXG2ANTTLib.OverviewVisibleEnum.exOverviewShowAll;
            chart.LevelCount = 3;
            chart.NonworkingDays = 0;
            chart.set_PaneWidth(0 != 0, 300);
            chart.FirstVisibleDate = DateFromString("9/1/2014");
            chart.HistogramVisible = true;
            chart.HistogramView = (exontrol.EXG2ANTTLib.HistogramViewEnum)65540;
            //var_Chart.HistogramView = exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramCheckedItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramUnlockedItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramLeafItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramNoGrouping | (exontrol.EXG2ANTTLib.HistogramViewEnum)0x10000;
            chart.HistogramHeight = 500;
            exontrol.EXG2ANTTLib.Bar var_Bar = chart.Bars["Task"];
            var_Bar.HistogramCriticalColor = Color.Red;
            var_Bar.HistogramPattern = (exontrol.EXG2ANTTLib.PatternEnum)512;
            var_Bar.HistogramType = exontrol.EXG2ANTTLib.HistogramTypeEnum.exHistOverAllocation;

            
            //Row and Bars definition

            exontrol.EXG2ANTTLib.Items items = exg2antt1.Items;

            foreach (var proj in projects)
            {
                int h = items.AddItem(proj.Name);
                items.AddBar(h, "Summary", proj.Start, proj.End, null, null);
                items.set_CellEditorVisible(h, 2, false);
                items.set_CellValue(h, 2, "");

                foreach (var task in proj.Tasks)
                {
                    int h1 = items.InsertItem(h, 0, task.Subject);
                    items.AddBar(h1, "Task", task.StartDate, task.DueDate, null, null);
                    //items.set_CellValue(h1, 3, task.Body);

                    items.DefineSummaryBars(h, "", h1, "");
                    items.set_ItemBar(h1, "", exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarEffort, 5);
                }

                items.set_ExpandItem(h, true);
                items.set_CellState(h, 1, 1);
            }

            //int h = items.AddItem("Project 1");
            //items.AddBar(h, "Summary", DateFromString("9/1/2014"), DateFromString("10/1/2014"), null, null);
            //items.set_CellEditorVisible(h, 2, false);
            //items.set_CellValue(h, 2, "");

            //int h1 = items.InsertItem(h, 0, "Task 1");
            //items.AddBar(h1, "Task", DateFromString("9/5/2014"), DateFromString("9/15/2014"), null, null);
            //items.set_CellValue(h1, 3, "Task 1 description");
            //items.DefineSummaryBars(h, "", h1, "");

            //h1 = items.InsertItem(h, 0, "Task 2");
            //items.AddBar(h1, "Task", DateFromString("9/9/2014"), DateFromString("9/11/2014"), "", null);
            //items.set_CellValue(h1, 3, "Task 2 description");

            //h1 = items.InsertItem(h, 0, "Task 3");
            //items.AddBar(h1, "Task", DateFromString("9/25/2014"), DateFromString("9/27/2014"), "", null);
            //items.set_CellValue(h1, 3, "Task 3 description");
            //items.DefineSummaryBars(h, "", h1, "");


            //h = items.AddItem("Project 2");
            //items.AddBar(h, "Summary", DateFromString("3/7/2005"), DateFromString("7/12/2005"), null, null);
            //items.set_CellEditorVisible(h, 2, false);
            //items.set_CellValue(h, 2, "");

            //h1 = items.InsertItem(h, 0, "Task 1");
            //items.set_CellValue(h1, 1, "Task 1 description");
            //items.AddBar(h1, "Task", DateFromString("7/3/2005"), DateFromString("7/8/2005"), null, null);
            ////items.set_CellMerge(h1, 0, 1);
            //items.DefineSummaryBars(h, "", h1, "");

            //h1 = items.InsertItem(h, 0, "Task 2");
            //items.set_CellValue(h1, 1, "Task 2 description");
            //items.AddBar(h1, "Task", DateFromString("7/5/2005"), DateFromString("7/12/2005"), "", null);
            ////items.set_CellMerge(h1, 0, 1);
            //items.DefineSummaryBars(h, "", h1, "");
            //items.set_ItemBar(h1, "", exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarEffort, 5);

            //h1 = items.InsertItem(h, 0, "Task 3");
            //items.set_CellValue(h1, 1, "Task 3 description");
            //items.AddBar(h1, "Task", DateFromString("7/7/2005"), DateFromString("7/8/2005"), "", null);
            ////items.set_CellMerge(h1, 0, 1);
            //items.DefineSummaryBars(h, "", h1, "");

            //items.set_ExpandItem(h, true);
            //items.set_CellState(h, 1, 1);

            exg2antt1.EndUpdate();
        }

        private void SetupGantt(List<ProjectItem> projects)
        {
            exg2antt1.BeginUpdate();

            exg2antt1.MarkSearchColumn = false;
            exg2antt1.Indent = 11;
            exg2antt1.HasLines = exontrol.EXG2ANTTLib.HierarchyLineEnum.exSolidLine;
            exg2antt1.Items.AllowCellValueToItemBar = true;

            exontrol.EXG2ANTTLib.Columns gridColumns = exg2antt1.Columns;

            gridColumns.Add("Tasks");

            exontrol.EXG2ANTTLib.Column startColumn = (gridColumns.Add("Start") as exontrol.EXG2ANTTLib.Column);
            startColumn.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellValueToItemBarProperty, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarStart);
            startColumn.Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DateType;
            startColumn.LevelKey = 1;

            exontrol.EXG2ANTTLib.Column endColumn = (gridColumns.Add("End") as exontrol.EXG2ANTTLib.Column);
            endColumn.set_Def(exontrol.EXG2ANTTLib.DefColumnEnum.exCellValueToItemBarProperty, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarEnd);
            endColumn.Editor.EditType = exontrol.EXG2ANTTLib.EditTypeEnum.DateType;
            endColumn.LevelKey = 1;

            exontrol.EXG2ANTTLib.Chart chart = exg2antt1.Chart;

            chart.FirstVisibleDate = DateFromString("8/25/2014");

            chart.HistogramVisible = true;
            chart.HistogramView = (exontrol.EXG2ANTTLib.HistogramViewEnum)65540;
            chart.HistogramView = exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramCheckedItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramUnlockedItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramLeafItems | exontrol.EXG2ANTTLib.HistogramViewEnum.exHistogramNoGrouping | (exontrol.EXG2ANTTLib.HistogramViewEnum)0x10000;
            chart.HistogramHeight = 500;
            //exontrol.EXG2ANTTLib.Bar var_Bar = chart.Bars["Task"];
            //var_Bar.HistogramCriticalColor = Color.Red;
            //var_Bar.HistogramPattern = (exontrol.EXG2ANTTLib.PatternEnum)512;
            //var_Bar.HistogramType = exontrol.EXG2ANTTLib.HistogramTypeEnum.exHistOverAllocation;

            
            chart.AllowCreateBar = exontrol.EXG2ANTTLib.CreateBarEnum.exCreateBarAuto;
            chart.LevelCount = 2;
            exg2antt1.Chart.AllowLinkBars = true;
            chart.set_PaneWidth(0 != 0, 200);

            
            exontrol.EXG2ANTTLib.Items ganttItems = exg2antt1.Items;


            foreach (var project in projects)
            {
                int h = ganttItems.AddItem(project.Name);
                ganttItems.AddBar(h, "Summary", DateFromString("9/1/2014"), DateFromString("10/1/2014"), null, null);
                ganttItems.set_CellEditorVisible(h, 1, false);
                ganttItems.set_CellEditorVisible(h, 2, false);
                ganttItems.set_ExpandItem(h, true);
                ganttItems.set_ItemBold(h, true);

                foreach (var task in project.Tasks)
                {
                    int h1 = ganttItems.InsertItem(h, 0, task.Subject);
                    ganttItems.AddBar(h1, "Task", task.StartDate, task.DueDate, null, null);

                    ganttItems.DefineSummaryBars(h, "", h1, "");
                    ganttItems.set_ExpandItem(h, true);
                    ganttItems.set_ItemBold(h, true);
                }
            }

            exg2antt1.EndUpdate();
        }

        private void exg2antt1_AddLink(object sender, string LinkKey)
        {
        }

        private void exg2antt1_CreateBar(object sender, int Item, DateTime DateStart, DateTime DateEnd)
        {

        }

        public List<ProjectItem> Projects { get; set; }

        private async void GanttDiagramForm_Load(object sender, EventArgs e)
        {
            //Debug.Assert(this.Projects != null, "Projects property should be set before showing hte GanttDiagramForm");

            //var projects = this.GenerateSampleData();
            //this.SetupGantt(projects);

            var userToken = LoginService.GetInstance().UserToken;
            var projects = await BackendServiceProxy.GetAllProjectsWithChildTasks(userToken);

            this.SetupGantt2(new List<ProjectItem>(projects.Projects));
            this.SetWin8Thema();
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SetWin8Thema()
        {
            exg2antt1.BeginUpdate();
            var var_Appearance = exg2antt1.VisualAppearance;
	            var_Appearance.Add(1,"gBFLBCJwBAEHhEJAAChABZUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFIBQTCIYhgHCRYDHAYIfDGJQ2DDKMgyBAcIwqAiEQimOa4VhEMg1CTPVARCKoYSDBKiaLgOL3fo0AIyTwAEQzVSNKxoAAEIRKAyTDLQdRyGSMMbgdDBBCbMiMRqhESIJjiA5USAGETNRS0LSbO68H4ed4rYr1ez1O7fN4PU6bW4FO59HhdLB6NblbznYw/b4Oc4uIrwdhxchedy3BxrHKaOo3egaFhjb5DUbUNJ0fStEwfJqtYJrcAggIA==");
	            var_Appearance.Add(45,"gBFLBCJwBAEHhEJAAChABZsGACAADACAxRDQOABQKAAzQFAYaBmGSGAAhcYYJhUAIIRZGMIjFDcEwxC6NIpAWCYRgUMQCQiOAwRCKQcBjD4YQIkGY4ZhyA42SBAcbyDCMShpF6EaAgSLxSjuGpGRjHdJRUYyTrQACmabiWbqCACVZVDJKEyReBUNAXDywIxqGoKOhaLA1CTZdowSKoYTXAa2bbmOi4Zp2Oo0XhAdSVUAEVRZFyYJDvGZJYjidIzTzQM7zBhkNyRCzHQpsEAAWxOFZjWLUeJVPhsbz5EKuIRyKA6fgPFZ3WJZOYyJDdUTVCK4dgtaIdAxPIwAXZlGBzJbcUhhGCSRqqXZaJzbO6IZrfEpcBQPBY/I6EdxjfQoAMb5HjMaxuEMLR1jMZ5djkR5aC6B54AOH4ohybg0F0e5EHwEQJCgGhMGcQ4pkiSxVCcQwIESX5EGQbQJAoEIXFGJxIAGBBYBgbQbjOIInBmIIoDIC4DGECA+BKA4hEgNQJgMT5ziCUYGGGOBqByB5hmiBgdHiII4F4C4ICIOIiCqCIhGQDgYgiIo4iYMIGiKzovgyI4IkYHINGMeJqDODgjkiHg/g+JAIhYLoQiOGQOD+EBGGkEhOg0JBoloSITmSGIQGaCYklkKhVgoJJJFIRIXGWKRSGCFpmBkQhXhGZYZhIaoYmWaQuFGDxmFkVhshwYwZk4aodGaeROHSG4mHkShphsZBZnYEYFGEOgOgaBJQhQBCAg=");
	            var_Appearance.Add(46,"gBFLBCJwBAEHhEJAAChABW8GACAADACAxRDQOABQKAAzQFAYaBmGSGAAhcYYJhUAIIRZGMIjFDcEwxC6NIpAWCYRDEMA4AJCI4DBCIZBiGyPRhASQZUhmHIDTbIEBxfIMIxLE6YaBjObIaoSGYfUhNMyTfA8EhjIScJRmWLwKhoC4eVhSUZSaKoSy5LyERpGCwIDqKZI0UjGNSzXTVFSZKQAJTlWT5RiObY0TjONo0XIlHSBJyoAAGuK2CArLIAAqxC54DozAZPRrcEg1JBODwHK6BcStTDLdjiXZfRDZWg2HCOJ4RSwALTxHLKbr6KIqlBkUZsQpORanaxGNr7BqVHZpSTbYD1KL8YADKK5YzGeb8VY+RTDUjEHJeN6wA4BDWYpmicXIMlgAARAkKAaEwZxDimSJLjUAATiGBAiG+JgyDaBIKCEPYKkAYgsBiUpdlybADgea55nsfxgAefgCH+IBHnUCR/E+M5MmWAhgjgKgMgOYJoEYDQ5GAZAOAiBIhAgTgZgYYRQAIF4GiGCIGCCBQfjgHZ7gaYgoiIE4HGGeIqC6BIikiHgpgyYg4kQcILziKg2g4I5ICoO4NCOWIQHCCYjHkAhGhCJBJAYOIPmOGQeAyEwkiiChQhOJQohYFoMiSWRmByFYhmkYhRg0ZZIjYVIYCQOReEWFokHkThohYZopH4T4YGAOAGAWHBnEhBJAEAgIA==");
	            var_Appearance.Add(47,"gBFLBCJwBAEHhEJAAChABa0IQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFICwTCIYhgHABIRHAYIRDIMQ2R6MQCSDKkMw5AabZAmWJYRiWJ4fDDMNBTXQkcxzD6iJ4hGRoHouQ44SjSMyUND1JQtFoaRJrCqoJDUMJcQLXVgVNK0OwHJCrJ6lCSpMhuL4xSLZFizRStJR7JafaajOj7ShWVJnXyAFpUBbgZSjQK6MRnK4qbw2XZfRDYUQ4Rb+FzJNTDZTmGRRWoHCJmABReA5RZmNyXTrDco0CyLWhuWaOWDkGL2HD7b5sADUZzyXTMfgEgI=");
	            var_Appearance.Add(48,"gBFLBCJwBAEHhEJAAChABRUMACAADACAxRDQOABQKAAzQFAYaBmGSGAAhcYYJhUAIIRZGMIjFDcEwxC6NIpBGCQCgkOA3STAYzjJCIYhuGaPRhASQZUhmHIDTbIEBxfIMIxSACTZhoKK5chqRYZR7SMyzJL9AwSGKPRojcYpfiGHwURoGEbVXAcfr/L4AK7feJoRDINQlWTZcQjKKFUQTNi3JppKKaYjuS53UzKEIyXJsXyiAq7aTnGabTjSPomDbQcCVHQ8LYaCauhb5DT1QTFCy8cSACoobpWRoJXSAGQQHTUB4nOyuYRfHSwAyteZkRraWw3CAFYTXNqIbrBCCdDADIanTpwMgzfZOaTMEtsez8RReC57XbTMohHJ8XgrkWa5bncHYdiUWgTlCURoCEPAMG2YwRD+FZMGWMBvCYRgrk6QJNG8Ph8mQN5UDiTxNHQMg9CacwjB8dQWAcEYzHYEA1kGSRMlcJ4FigAAaFAAZfEeWRVg2VRCGAQABkccphgcNgKgOEIYDWIR7BMWBWBcdpVDYAgLgSXwGA2bR8AAB5JHsSwUnWeQbgIHAYiGAYKiCOIwACCIWHUTZLGEYxll4OBwiKSJxkwTgcjSfZ/FgI4pA4IBTBSd5dBsRAjBCTRlAwAwWmUJB/hkFoFj2DoemYRZfBQBoRgwdAdEcIYVFAQhKmAGQDBCBJZjUGQNhCEIiB0eIVjgNQDB4JppgEYofmgBo5i4NpoEoFoGiGaIKCaCoimiBo6gCI" +
            "5PnoDoHC8KRKFaFolmmChmhqJttEKARqmgWhgh6KJqEqFomimaoKiaJImCgWoqi6K5rAqRoviUapa1OLZrgqZo6iQKh6lKBIpCuOwGkKMIrloUo1CeLA7CaSojmwUpykeMptAsKpNjObQbFaO40muepalaNprHsYJbjALZLgaAI3i4C+KjkLYrhqYo6CyC4qmuKeFH6aY7i2O4ynSOBqjoXpUj2bRrmaTohm4W5ylGKQolaLwBkCLI6hKApCnAfAikmQxWCwQwOjAcQjn8FZEmuHBWjKRtDnabYkBAECAg");
	            var_Appearance.Add(41,"gBFLBCJwBAEHhEJAAChABV8MACAADACAxRDQOABQKAAzQFAYaBmGSGAAhcYYJhUAIIRZGMIjFDcEwxC6NIpAWLoJDCH4mSTHYwgJIMWwzDiBZgkCA4fiGEYnThGc4ydKsNAFEiaIycFzHaACQ5FRTOYASRKMTx/HiEQRjIC6AjOFpHUZRETRCKQahLLivIhGUYKfgmY5lVBAdLxNSVAxdN6rKYpOihSiOcIuTJMUbzbDMbxTP6mcAlW7AABaCZrBhVMSuM5bYgBRjHKRwK4hSo6b4fWzhMI1JAeEzdCzIMbxWq4bqHJZoABZdhWJCMQw/NbDIDzHLrXy7E4fZTgWzRTp8E5jWqNKSyTJrJADGYfZxmXARVYGUS7VDVLK1SZ1FaV4Yl8cpynCEBECSIBpDGHQOicIwokYPoWgYEIJj4eJIloEgok2Qh2hCDYkAyQYtlqPBdG4b5Pm+dZ8H+X5oAWfYAl+RAlnwP4PlOcgIgKIIYC4DoDGECAwnyARQDOSZ6gKT4zlScYGGGOBqByB5hmgagLgWDhkCYoYiBgdgqggIoog2eoJg6M4WAgPxikiVgpgcIw4FiZRCE8OJGDMPpPGgbhBhAJApBYRIRCMOJ2DsQJkiiTJ8hAZJzkYUYUmUCUpBIYwYnIPg/GCE5YnKE5lnkehghiZgpHoWISkAA5SDEP5gjOXhfhuD5JkIcobmcSYwn2GomgmKJkh2JwZlIfYfmcOZ2HaHoQhOVJsh6Yw5jifc0EOSoLiOK" +
            "JZlqBg5CgWgeHaIpPDoYoaD2aYaHKGw8mkKgdAkPYpGoJodimaZ6H4dopCkRAOiQOJpHOYoZiyD5alKNosmuCosmwOJqDqboxi4KxbAKN4wGuKpxAMPZrvIQ4ymwKoCAiMgsGAApQh2D5qkqVQ8m0exmlaNpsmoLo7EIbQ4CCfg+E8S4OmWOQuGuJpojkJxrEECQ+A6Q4KlSOpuHuVpqj0ZxrkCYo7m8G5OnaPQvHuGp5jwUITmafYCA+e4zAoPQwhwMwLkMZxsBqexAnEKZbAkPRxHwZJ5kYMY8GsGICDELAXAcPxPnPyZJjIXIfCqShykyAwEECT4jjCYZFjCDJXCSTYzEyXJ9kwTgUCUASAgA==");
	            var_Appearance.Add(42,"gBFLBCJwBAEHhEJAAChABb8GACAADACAxRDQOABQKAAzQFAYaBmGSGAAhcYYJhUAIIRZGMIjFDcEwxC6NIpAWCYRDEMA4AJCI4DBCIZBiGyPRhASQZUhmHIDTbIEBxfIMIxLE6YaBjObIaoSGYfUhGSqUWAFFpZCyfYLhEYaCjiKY1R6CUZAXD1OwzJymaYiWTRVCWZJmQiNIwWRAdVTZGikYxrKa5VrWA5RVaAEpybJ8YxHOyaZxnG9MfSnICpapAAYqGhbuCvha5DCtQTBMbDaigTChSrmIZZQjkEB1ZAeJzpL6mMrkSK7FqeEZua7acQ5fiORABObJMAmW6JKDCMYlDZVFy4mTbOoZbxAcp7fSfA49IqEdwjfRAA4bR5ME4NY6ksfpClOMoNF4cIaAgHxbi8R4EgIIQlAMSYMmgdQ5BkeBQDEVAwgQTZ6EYRpQhERAnimJhIKEWJ0HOWAFDoBoBmCCAmAoQhUmOFgOgOYQIEYEoEhqKA2BOBZhggOgVFKThoHYHoHmICIGCGBpKkiCgmgmYZohCZ4KmKSI2C6C5iniEJogyYxIlYNoNmMeJKDiDpjkiTgkDoZAJAYQoQmQSQSCQOokgkJhKhKZJJDIR4TGUCRGEiCQOjkVhWhWZYJGYWdKkkdheheZgJgYYYXCYKYWGaFxiEONhqhqZpJjYbobiIQ46HKHJnEmVh2h2JwZl4eoemcKIQm+H5oAoBoCiCaA5nqBIhmiCZ+CQPAokoNoOiOaUdCSA" +
            "opEoVYqEAQCAg=");
	            var_Appearance.Add(2,"gBFLBCJwBAEHhEJAAChABZsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDTLeN5XXblez9P7AMBwLFDC4NQ7EMRxLC8MKDDqFY4YGKXXiOIz/SrHcjvHKMVxvHKZZpeWb6HoOA5HSTScg0DSdMy3LqvbBsOxbHp0AkBA=");
	            var_Appearance.Add(3,"gBFLBCJwBAEHhEJAAChABc0IQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHZgTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDTLeN5XXblez9P4wHgwLAMEwXBaCPBhWJYXbOEYZR7DcDyDI7dw7BD/ZhieYPfiOE4vTbMb60DQcAxbAKjaBeOoZXjuNZXVbFdK1bYMPzLD6sZRtWSbTiWd59XTfNp3XgcT4DRKKcZxeawCEBA==");
	            var_Appearance.Add(4,"gBFLBCJwBAEHhEJAAChABZsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDTLeN5XXblez9P7AMBwLFDC4NQ7EMRxLC8MT/DqFY4veKXXiOIz/SrHcjvHKMVxvHKZZpeWb6HoOA5HSTScg0DSdMy3LqvbBsOxbHp0AkBA=");
	            var_Appearance.Add(5,"gBFLBCJwBAEHhEJAAChABcMIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDNpeN5XXblez9P7AJjeDAMEwXBp6YJheJYXhEZ4ZR7DMRyDI7exLBIJYrmGC5NgEM47CzIcawWaLayTG6iYbdYAYXjmFZNRjWcYzLI9RxTNKobZtWy7TqGcZ5SDdd7wfgeCydcIBgIA=");
	            var_Appearance.Add(6,"gBFLBCJwBAEHhEJAAChABWUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUEgfDqaZxkKQAIgkUBpGKdBynEYoYxAMyGCCJWk6bQSFCNZwgOCAYhYMIRTpFLK1XTlOy9L6wLBsJ4LEqKZpnWhXFiPBZNWzdNSybbuKx7LrOdphXTdd5XBZldz3PK/LrwDAbTwPBJvYZhdq4ThVUYZRqzMbyC6LRxOaaSZZXWYZTbkAkBA");
	            var_Appearance.Add(7,"gBFLBCJwBAEHhEJAAChABWUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUEgfDqaZxkKQAIgkUBpGKdBynEYoYxAMyGCCJWk6bQSFCNZwgOCAYhYMIRTpFJgVXTlOy9L6wLBsJ4LEqKZpnWhXFiPBZNWzdNSybbuKx7LrOdphXTdd5XBZldz3PK/LrwDAbTwPBJvYZhdq4ThVUYZRqzMbyC6LRxOaaSZZXWYZTbkAkBA");
	            var_Appearance.Add(8,"gBFLBCJwBAEHhEJAAChABWUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUEgfDqaZxkKQAIgkUBpGKdBynEYoYxAMyGCCJWk6bQSFCNZwgOCAYhYMIRTpFKjVXTlOy9L6wLBsJ4LEqKZpnWhXFiPBZNWzdNSybbuKx7LrOdphXTdd5XBZldz3PK/LrwDAbTwPBJvYZhdq4ThVUYZRqzMbyC6LRxOaaSZZXWYZTbkAkBA");
	            var_Appearance.Add(10,"gBFLBCJwBAEHhEJAAChABZcIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDTLeN5XXblez9P7AMBwLFDC4NQ7EMRxLC8Mr8YKPYziOL5HimI4FSjMMxya68ZxOeadZBmeZXdoeLY9QjTcz1LS9My3LqvbBsOrQCEBA");
	            var_Appearance.Add(11,"gBFLBCJwBAEHhEJAAChABdUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDGBeN5XXblez9P7AJjeDAMEwXBp6YJheJYXhEZ4ZR7DMRyDI7exLEz/ZhlBgZNheMY9T7IM4wXL9EyXC6iX5pObXVpWM4LVC+dKvfYsEzCfKrYpuGy4djWe43XjfMo2bgcH4PRKvcBxeKcNxVf4FAMBA");
	            var_Appearance.Add(12,"gBFLBCJwBAEHhEJAAChABZcIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDTLeN5XXblez9P7AMBwLFDC4NQ7EMRxLC8MueR7GcRxfI8UxHAqUZhmOTXXjOJzzTrIMzzK7tDxbHqEabmepaXpmW5dV7YNh1aAQgIA=");
	            var_Appearance.Add(13,"gBFLBCJwBAEHhEJAAChABckIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQIhEIZYj2HwFS5LAqjJQEBxeFoZY7GeLxWj2MY5qChEC4JAyTpXSJCIIQSSBUjGOg6TiMUYYfKaDBCEzZUY0bAYUQSCCdZrDCJhQhGWIDNpeN5XXblez9P7AJjeDAMEwXBp6YJheJYXhEZ4ZR7DMRyDI7exLE4JZQ2WTYXLGIY3Qq7QAxPL7ex2eamYRpF6xTgGWYLVS+MwxLYtJw7Ga3ZptW4ZJqGd4PXrfNb3LgcM4DRJ/YJAIEBA=");
	            var_Appearance.Add(14,"gBFLBCJwBAEHhEJAAChABSsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNw7GqcJCkACIJJAaRjHQdJxGKKMQItBghCZoeKRWgkKI2QKEUyBRCxQQjHKKXgrKq6cp2XpfWBYNhWHYlSzNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgNZwCEBA==");
	            var_Appearance.Add(18,"gBFLBCJwBAEHhEJAAChABcEIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJUSAE6QGBcEyrJysJrgMCIJJAaRjHQdJxGKKMPjtBghCZseKRWgkKI5qAmcKIWICEZZQLMd5XXblez9P7AL6ADAcEwXBp8YLheJYXhGGYdRbEcbyLAcRxMYKXZhmGLZLhmM49SbOMKzbKcTrrIaAaLmWi3Xo+CZTS7VXg1XQtPyDMavGBmew7XKmeZ3WbfMS4DgcGACAUB");
	            var_Appearance.Add(19,"gBFLBCJwBAEHhEJAAChABbsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJUSAE6QGBcEyrJysJrgMCIJJAaRjHQdJxGKKMPjtBghCZseKRWgkKI5qAmcKIWICEZZQLMd5XXblez9P7AL6ABqsEwXBqHYhiOJYXhGB4ZR7IMhwbDsS1FSbLcxybJMawSOKZZxleb5boOI5HTrPMp0fSMFyXEKraRqGwZXpmPRDUDadxzDatay7PK4b7tIAQCEBA=");
	            var_Appearance.Add(20,"gBFLBCJwBAEHhEJAAChABcEIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJUSAE6QGBcEyrJysJrgMCIJJAaRjHQdJxGKKMPjtBghCZseKRWgkKI5qAmcKIWICEZZQLMd5XXblez9P7AL6ADAcEwXBp8YLheJYXhGGYdRbEcbyLAcRxNP6XZhmGLZLhmM49SbOMKzbKcTrrIaAaLmWi3Xo+CZTS7VXg1XQtPyDMavL7mew7XKmeZ3WbfMS4DgcGACAUB");
	            var_Appearance.Add(21,"gBFLBCJwBAEHhEJAAChABdUIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJUSAE6QGBcEyrJysJrgMCIJJAaRjHQdJxGKKMPjtBghCZseKRWgkKI5qAmcKIWICEZZQLMd5XXblez9P7AL8bBgmC4NQ7EMRxLC8IwPDKPZBkODYdiWoqTZbmOTZJjWCL/T7QNAzHLMXyHJqdGBpGQ6NoOUYLVTFdY0LTsYyXMj/bRqOobPrGO5hWzZND3HlDf6JS7jOLyXieKxEAIBgI=");
	            var_Appearance.Add(22,"gBFLBCJwBAEHhEJAAChABTsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNwSB6aZxkKQAIgkUBpGKdBynEYoYxBBaBSCJWiIWDaCQoTZAcaQHBAMQzCKdIpeCq6cp2XpfWBYNhVYxtSzNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgOBYHgmC4NQ7ELogEEBA==");
	            var_Appearance.Add(23,"gBFLBCJwBAEHhEJAAChABT0IQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNwSB6aZxkOZIDAiCRQGiYZyHKaRShjECFYDIIjaJhYNoJChNUBxZAcEAxDKIZyiV4Kcp2XpfWBYNhWHTpQTNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgOBYHgmC4NQ7EMRuWAQgI=");
	            var_Appearance.Add(25,"gBFLBCJwBAEHhEJAAChABTsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNwSB6aZxkKQAIgkUBpGKdBynEYoYxBBaBSCJWiIWDaCQoTZAcaQHBAMQzCKdIpeCq6cp2XpfWBYNhVYo1SzNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgOBYHgmC4NQ7ELogEEBA==");
	            var_Appearance.Add(26,"gBFLBCJwBAEHhEJAAChABbsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJAZOcIgZBIFydK6RIRBCCSQKkYx0HScRijDD5bQYIQmbKjEZoJCiOYJBBNYYRMQEIyxAaZbxvK67cr2fp/XyAGAYoYWe6CYZiOJYPheG4VRDHMhwDIMJKDFqXZbkV45JheMY9STOMazbKMNyHEqjZjhWjZbpBQZLU7WdAxXTdOxpcKrbZkO4bTp+eZ5XbfMRACAQgI");
	            var_Appearance.Add(27,"gBFLBCJwBAEHhEJAAChABbsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJAZOcIgZBIFydK6RIRBCCSQKkYx0HScRijDD5bQYIQmbKjEZoJCiOYJBBNYYRMQEIyxAaZbxvK67cr2fp/XyADZYoYXBqHYhiOJYPgWF4dR7IMJxXIcUxXEqWZhlOR5JLGM4NTbLM5zbQMZyLGqeYhpWL6JjGVYjVjXZB1DYMLy7JaobhiOybTq+eZ8bTdd7zSAQgI");
	            var_Appearance.Add(28,"gBFLBCJwBAEHhEJAAChABbsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJAZOcIgZBIFydK6RIRBCCSQKkYx0HScRijDD5bQYIQmbKjEZoJCiOYJBBNYYRMQEIyxAaZbxvK67cr2fp/XyAGAYoYWe6CYZiOJYPheG4VRDHMhwDIMJT/FqXZbkV45JheMY9STOMazbKMNyHEqjZjhWjZbpCf5LU7WdAxXTdOxpcKrbZkO4bTp+eZ5XbfMRACAQgI");
	            var_Appearance.Add(29,"gBFLBCJwBAEHhEJAAChABc8IQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEYobgmGIXRpFMbxCKQahLEiTIhGUYJHgmK4tQLHbwTGAABQ9EKEQhhEBJYj2HwFS5LAqjHQEBxeFoaI7GaLxXj2MYJAZOcIgZBIFydK6RIRBCCSQKkYx0HScRijDD5bQYIQmbKjEZoJCiOYJBBNYYRMQEIyxAaZbxvK67cr2fp/XyABgYoYXBqHYhiOJYPgWF4dR7IMJxXIcUxXEqWZhlOR5I7+O49TzMcKzPJsfyXIRgaLmOi5fjGU5PVbQMh1bRNQb/LavbTpex4XqubZPQbdd70HgeCzfRbHahyHDgBAIgI=");
	            var_Appearance.Add(30,"gBFLBCJwBAEHhEJAAChABSsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNw7GqcJCkACIJJAaRjHQdJxGKKMQItBghCZoeKRWgkKI2QKEUyBRCxQQjHKKXgrKq6cp2XpfWBYNhWHYlSzNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgNZwCEBA==");
	            var_Appearance.Add(31,"gBFLBCJwBAEHhEJAAChABSsIQAAYAQGKIaBwAKBQAGaAoDDQMwyQwAELjDBMKgBBCLIxhEIIJBGCYYRbGUSyBCIZBqEqSZLiEZRQiiCYsS5GIBRfIUNw7GqcJCkACIJJAaRjHQdJxGKKMQItBghCZoeKRWgkKI2QKEUyBRCxQQjHKKXgrKq6cp2XpfWBYNhWHYlSzNM60LRtKy7Mq2bpvXBcNxXHalaztO68LxvK67cr2fp/YBgNZwCEBA==");
            exg2antt1.BackColor = Color.FromArgb(255,255,255);
            exg2antt1.BackColorLevelHeader = Color.FromArgb(255,255,255);
            exg2antt1.BackColorHeader32 = 0x1000000;
            exg2antt1.SelBackColor32 = 0x2d000000;
            exg2antt1.SelForeColor = Color.FromArgb(0,0,0);
            exg2antt1.HotBackColor32 = 0x2e000000;
            exg2antt1.HotForeColor = Color.FromArgb(0,0,0);
            var var_Chart = exg2antt1.Chart;
	            var_Chart.BackColorLevelHeader32 = 0x1000000;
	            var_Chart.BackColor = Color.FromArgb(255,255,255);
	            var_Chart.Bars["Task"].Color32 = 0x2a000000;
	            var_Chart.NonworkingDaysColor = Color.FromArgb(240,240,240);
            exg2antt1.FilterBarBackColor32 = 0x1000000;
            exg2antt1.ScrollBars = exontrol.EXG2ANTTLib.ScrollBarsEnum.exDisableBoth;
            exg2antt1.ScrollHeight = 17;
            exg2antt1.ScrollWidth = 17;
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exCursorHoverColumn, 0x29000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exToolTipAppearance,0x30000000);
            exg2antt1.set_Background32((exontrol.EXG2ANTTLib.BackgroundPartEnum)0x10 | exontrol.EXG2ANTTLib.BackgroundPartEnum.exCellButtonUp,0x2f000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSUp,0x2000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSUpP,0x3000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSUpD,0x4000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSUpH,0x5000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSThumb,0x6000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSThumbP,0x7000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSThumbH,0x8000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSDown,0xa000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSDownP,0xb000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSDownD,0xc000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSDownH,0xd000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSBack,0xe000000);
            exg2antt1.set_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSLower,exg2antt1.get_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSBack));
            exg2antt1.set_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSUpper,exg2antt1.get_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exVSBack));
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSLeft,0x12000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSLeftP,0x15000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSLeftD,0x14000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSLeftH,0x13000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSThumb,0x16000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSThumbP,0x17000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSThumbH,0x19000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exScrollSizeGrip,0x1f000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSRight,0x1a000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSRightP,0x1d000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSRightD,0x1c000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSRightH,0x1b000000);
            exg2antt1.set_Background32(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSBack,0x1e000000);
            exg2antt1.set_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSLower,exg2antt1.get_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSBack));
            exg2antt1.set_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSUpper,exg2antt1.get_Background(exontrol.EXG2ANTTLib.BackgroundPartEnum.exHSBack));
            exg2antt1.EndUpdate();
        }

        private void exg2antt1_HistogramBoundsChanged(object sender, Rectangle Bounds)
        {
            panel2.Bounds = Bounds;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            exontrol.EXG2ANTTLib.Bar bTask = exg2antt1.Chart.Bars["Task"];
            exg2antt1.BeginUpdate();
            if (bTask.HistogramType == exontrol.EXG2ANTTLib.HistogramTypeEnum.exHistOverAllocation)
            {
                bTask.HistogramType = exontrol.EXG2ANTTLib.HistogramTypeEnum.exHistOverload;
                bTask.HistogramPattern = bTask.Pattern;
                exg2antt1.Columns[1].Visible = false;
            }
            else
            {
                bTask.HistogramType = exontrol.EXG2ANTTLib.HistogramTypeEnum.exHistOverAllocation;
                bTask.HistogramPattern = (exontrol.EXG2ANTTLib.PatternEnum)512;
                exg2antt1.Columns[1].Visible = true;
            }
            exg2antt1.EndUpdate();
        }
    }
}