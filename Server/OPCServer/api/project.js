var crypto = require('crypto');
var assert = require('assert');
var dalService = require('../dal/dalService');

var user = require('./user');
var ObjectID = require('mongodb').ObjectID;

exports.create = function (req, res) {
    var userToken = req.body.UserToken;
    var project = req.body.Payload;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    dalService.insert("projects", getObjectWithoutId(project), function (err, result) {
        var errMsg = "";
        if (err != null) {
            errMsg = "An error occured while creating a project. Details: " + err.message;
        }
        
        if (!result || result.length === 0) {
            errMsg = "An error occured while creating a project.";
        }
        
        if (errMsg) {
            res.send({
                success : false,
                msg: errMsg
            });
            return;
        }
        
        var projectId = new ObjectID(result[0]._id);

        res.send({
            success : true,
            ProjectId: projectId.toHexString(),
            msg: "OK"
        });
    });
}

var getObjectWithoutId = function (object) {
    if (!object) {
        return null;
    }

    var result = {};

    for (var propName in object) {
        if (propName === "Id" || propName === "Tasks") {
            continue;
        }

        if (object.hasOwnProperty(propName)) {
            result[propName] = object[propName];
        }
    }

    return result;
}

exports.update = function (req, res) {
    var userToken = req.body.UserToken;
    var project = req.body.Payload;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    dalService.update("projects", { _id: new ObjectID(project.Id) }, getObjectWithoutId(project), function (err, result) {
        if (err !== null) {
            res.send({
                success : false,
                msg: "An error occured while updating a project."
            });

            return;
        }

        res.send({
            success : true,
            msg: "OK"
        });
    });
}

exports.delete = function (req, res) {
    var userToken = req.params.userToken;
    var projectId = req.params.id;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    dalService.remove("projects", { _id: new ObjectID(projectId) }, function (err, numberOfRemovedDocs) {
        if (err !== null) {
            res.send({
                success : false,
                msg: "An error occured while deleting a project."
            });
            
            return;
        }

        res.send({
            success : true,
            msg: "OK"
        });
    });
}

exports.getAll = function (req, res) {
    var userToken = req.params.userToken;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }
    
    var select = dalService.select("projects");
    dalService.executeSelect(select, function (err, projects) {
        assert.equal(null, err);
        
        var results = [];

        for (var i = 0; i < projects.length; i++) {
            var project = projects[i];

            var item = {
                Id: project._id.toString(),
                Name: project.Name,
                InternalCode: project.InternalCode,
                Description: project.Description
            };

            results.push(item);
        }

        res.send({
            success: true,
            projects: results,
            msg: "OK",
        });
    });    
}

exports.getAllWithTasks = function (req, res) {
    var userToken = req.params.userToken;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    var select = dalService.select("projects").join(dalService.select("tasks"), "ProjectId", "Tasks");
    dalService.executeSelect(select, function (err, projects) {
        var results = [];

        for (var i = 0; i < projects.length; i++) {
            var project = projects[i];
            
            var item = {
                Id: project._id.toString(),
                Name: project.Name,
                InternalCode: project.InternalCode,
                Description: project.Description,
                Tasks: project.Tasks
            };
            results.push(item);
        }

        res.send({
            success: true,
            projects: results,
            msg: "OK",
        });
    });
}

exports.getById = function (req, res) {
    var userToken = req.params.userToken;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }
}

exports.projectPlan = function (req, res) {
    var userToken = req.params.userToken;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    res.send({
        data: JSON.stringify(projectPlan),
        success: true,
        msg: "OK"
    });
}

var projectPlan =
 {
    Upload: { Format: "JSON" },
    Layout:
 {
        Data:
 {
            Cfg:
 {
                id: "GanttSimple", 
                MainCol: "T",
                Style: "office",
                MaxHeight: "1",
                MaxHeightReserved: "10",
                ScrollLeftLap: "0",
                NoTreeLines: '1'
            },
            Def:
 [
                            {
                Name: "R",
                DefParent: "Task"
            },
                            {
                Name: "Task",
                DefEmpty: "R",
                Expanded: "1", 
                Calculated: "1", 
                CalcOrder: "S,E,C,G",
                SFormula: "minimum(min('S'),min('E'))",
                EFormula: "maximum(max('S'),max('E'))",
                CFormula: "ganttpercent('S','E','d')",
                DButton: "",
                GGanttClass: "Group", 
                GGanttIcons: "1", 
                GGanttEdit: "0", 
                GGanttHover: "0"
            }
                        ],
            Panel:
 {
                Copy: "7"
            },
            LeftCols: 
 [
                            { Name: "id", Width: "40", Type: "Text", CanEdit: "0" },
                            { Name: "T", Width: "140", Type: "Text" },
                            { Name: "S", Width: "100", Type: "Date", Format: "yyyy-MM-dd" },
                            { Name: "E", Width: "100", Type: "Date", Format: "yyyy-MM-dd" },
                            { Name: "C", Width: "100", Type: "Float", Format: "##.##\%;;0\%" },
                            { Name: "D", Width: "65", Type: "Text", CanEdit: "0", Button: "Defaults", Defaults: "|*RowsColid*VariableDef", Range: "1" },
                            { Name: "X", Visible: "0", Type: "Int" }
                        ],
            Cols:
 [
                            {
                Name: "G", Type: "Gantt", GanttStart: "S",
                GanttEnd: "E", GanttComplete: "C", GanttDescendants: "D", GanttDisabled: "X",
                GanttUnits: "d", GanttWidth: "18", GanttChartRound: "w", GanttRight: "1",
                GanttHeader1: "w#dddddd MMMM yyyy", GanttHeader2: "d#ddddd",
                GanttBackground: "w#1/6/2008~1/6/2008 0:01",
                GanttEdit: "Main,Dependency",
                GanttSlack: "1",
                GanttCorrectDependenciesFixed: "1"
            }
                        ],
            Header: 
 {
                id: "ID", T: "Name", S: "Start", E: "End", C: "Complete", G: "Gantt", D: "Next"
            },
            
            Toolbar: { Formula: "ganttdependencyerrors(null,1)", FormulaOnClick: "CorrectAllDependencies", FormulaTip: "Click to correct the dependencies" },
            
            Solid:
 {
                Topbar:
 {
                    id: 'Project', Space: '0', Panel: '0', Cells: 'Base,Finish',
                    BaseType: 'Date', BaseCanEdit: '1', BaseWidth: '80', BaseUndo: '1', BaseLeft: '5',
                    BaseLabel: 'Start date',
                    BaseFormat: "ddd M/d/yyyy",
                    BaseEditFormat: 'M/d/yyyy',
                    BaseFormula: 'Grid.GetGanttBase()',
                    BaseOnChange: 'Grid.SetGanttBase(Value,2);',
                    BaseHtmlPrefixFormula: 'Grid.Cols.G.GanttBase===""?"&lt;span style=&apos;color:gray;&apos;>":"&lt;span>"',
                    BaseHtmlPostfix: '&lt;/span>',
                    BaseTip: 'Starting date of the whole project.&lt;br>No task should start before it.&lt;br>It is also used when correcting dependencies.',
                    
                    FinishType: 'Date', FinishCanEdit: '1', FinishWidth: '80', FinishUndo: '1', FinishLeft: '5',
                    FinishLabel: 'Finish date',
                    FinishFormat: "ddd M/d/yyyy",
                    FinishEditFormat: 'M/d/yyyy',
                    FinishFormula: 'Grid.GetGanttFinish()-24*60*60*1000',
                    FinishOnChange: 'Grid.SetGanttFinish(Value+24*60*60*1000);',
                    FinishHtmlPrefixFormula: 'Grid.Cols.G.GanttFinish===""?"&lt;span style=&apos;color:gray;&apos;>":"&lt;span>"',
                    FinishHtmlPostfix: '&lt;/span>',
                    FinishTip: 'Finish date of the whole project.&lt;br>If grayed, it is calculated from the last task.&lt;br>It is used to calculate critical path.'
                }
            }
        }
    },
    Data:
 {
        Data:
 {
            Body:
 [
                                    [
                                         {
                id: "1", T: "Project 1", Def: "Task", S: "10/1/2014", E: "10/25/2014",
                Items:
 [
                                                 { id: "11", T: "SubTask1", C: "100", S: "10/18/2014", E: "10/20/2014", D: "12;13" },
                                                 { id: "12", T: "SubTask2", C: "25", S: "10/21/2014", E: "10/30/2014" },
                                                 { id: "13", T: "SubTask3", C: "50", S: "10/21/2014", E: "10/30/2014" }
                                             ]
            },
                                         {
                id: "2", T: "Project 2", Def: "Task",
                Items:
 [
                                                 { id: "21", T: "Subtask 1", C: "100", S: "10/14/2014", E: "10/21/2014", D: "22" },
                                                 {
                    id: "22", T: "Subtask 2", Def: "Task", D: "", 
                    Items:
 [
                                                     { id: "221", T: "Subtask 2-1", C: "100", S: "10/22/2014", E: "10/24/2014", D: "23" },
                                                     { id: "222", T: "Subtask 2-2", C: "50", S: "10/21/2014", E: "10/29/2014" },
                                                     { id: "223", T: "Subtask 2-3", C: "0", S: "10/30/2014", E: "10/31/2014" },
                                                 ]
                },
                                                 { id: "23", T: "Subtask 3", C: "0", S: "10/10/2014", E: "10/15/2014", D: "1" },
                                             ]
            }
                                    ]
                                ]
        }
    }
};
