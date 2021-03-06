$(document).ready(function () {

    var datasource = new kendo.data.DataSource({
        transport: {
            read: { url: "/Admin/GetUsers", cache: false },
            update: { url: "/Admin/GetUsers", cache: false }
        },
        schema: {
            model: {
                id: "id",
                fields: {
                    email: { validation: { required: false } },
                    isAdmin: { validation: { required: false } },
                    isBlock: { validation: { required: false } },
                }
            }
        }
    })

    $("#grid").kendoGrid({
        columns: [
            { field: "id", hidden: true },
            { field: "email", title: "Email", editable: false },
            { field: "isBlock", title: "IsBlocked", editable: false },
            { field: "isAdmin", title: "IsAdmin", editable: false},
            { command: [{ text: 'open', click: openread }, { text: 'setblock', click: setblock }, {text: 'setadmin', click: setadmin}, { text: 'delete', click: deleteuser }], width: 400},

        ],
        dataSource: datasource,
        pageable: true,
        sortable: true,
        navigatable: true,
        resizable: true,
        reorderable: true,
        groupable: true,
        filterable: true,

    });
})


var deleteuser = function (e) {
    var tr = $(e.target).closest("tr");
    var id = this.dataItem(tr).id;
    kendo.confirm("Are you sure that you want delete this user?").then(function () {
        $.post('/Admin/DeleteUser', { '': id }, function () {
            $("#grid").data("kendoGrid").dataSource.read();
        });
    }, function () { });
}

var setblock = function (e) {
    var tr = $(e.target).closest("tr");
    var id = this.dataItem(tr).id;
    kendo.confirm("Are you sure that you want to change the state of this user?").then(function () {
        $.post('/Admin/SetBlock', { '': id }, function () {
            $("#grid").data("kendoGrid").dataSource.read();
        });
    }, function () { });
}

var setadmin = function (e) {
    var tr = $(e.target).closest("tr");
    var id = this.dataItem(tr).id;
    kendo.confirm("Are you sure that you want to change the state of this user?").then(function () {
        $.post('/Admin/SetAdmin', { '': id }, function () {
            $("#grid").data("kendoGrid").dataSource.read();
        });
    }, function () { });
}
