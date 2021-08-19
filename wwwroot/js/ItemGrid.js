$(document).ready(function () {

    var datasource = new kendo.data.DataSource({
        transport: {
            read: { url: "/Collection/GetItems", data: { 'Id': collectionId }, cache: false },
            update: { url: "/Collection/GetItems", data: { 'Id': collectionId }, cache: false }
        },
        schema: {
            model: {
                id: "id",
                fields: {
                    name: { validation: { required: true }},
                    tags: { validation: { required: false }},
                    boolean1: { validation: { required: false }},
                    boolean2: { validation: { required: false }},
                    boolean3: { validation: { required: false }},
                    date1: { validation: { required: false }},
                    date2: { validation: { required: false }},
                    date3: { validation: { required: false }},
                    integer1: { validation: { required: false }},
                    integer2: { validation: { required: false }},
                    integer3: { validation: { required: false }},
                    line1: { validation: { required: false }},
                    line2: { validation: { required: false }},
                    line3: { validation: { required: false }},
                    text1: { validation: { required: false }},
                    text2: { validation: { required: false }},
                    text3: { validation: { required: false }},
                }
            }
        }
    })

    $("#grid").kendoGrid({
        columns: [
            { field: "id", hidden: true },
            { field: "name", title: "Name", editable: false},
            {
                field: "tags", title: "Tags", template: function (dataItem) {
                    var html = []
                    for (var i = 0; i < dataItem["tags"].length; i++) {
                        html.push(dataItem["tags"][i].name)
                    }
                    return html.join(', ')
                }
            },
            { field: "boolean1", title: b1, type: "boolean", hidden: CheckNullOrEmpty(b1) },
            { field: "boolean2", title: b2, type: "boolean", hidden: CheckNullOrEmpty(b2) },
            { field: "boolean3", title: b3, type: "boolean", hidden: CheckNullOrEmpty(b3) },
            { field: "date1", title: d1, type: "date", hidden: CheckNullOrEmpty(d1) },
            { field: "date2", title: d2, type: "date", hidden: CheckNullOrEmpty(d2) },
            { field: "date3", title: d3, type: "date", hidden: CheckNullOrEmpty(d3) },
            { field: "integer1", title: i1, type: "number", hidden: CheckNullOrEmpty(i1) },
            { field: "integer2", title: i2, type: "number", hidden: CheckNullOrEmpty(i2) },
            { field: "integer3", title: i3, type: "number", hidden: CheckNullOrEmpty(i3) },
            { field: "line1", title: l1, type: "string", hidden: CheckNullOrEmpty(l1) },
            { field: "line2", title: l2, type: "string", hidden: CheckNullOrEmpty(l2) },
            { field: "line3", title: l3, type: "string", hidden: CheckNullOrEmpty(l3) },
            { field: "text1", title: t1, type: "text", hidden: CheckNullOrEmpty(t1) },
            { field: "text2", title: t2, type: "text", hidden: CheckNullOrEmpty(t2) },
            { field: "text3", title: t3, type: "text", hidden: CheckNullOrEmpty(t3) },
            { command: [{ text: 'edit', click: edititem }, { text: 'open', click: openread }, { text: 'delete', click: deleteitem }],width:230 },

        ],
        dataSource: datasource,
        edit: function (e) {
            e.container.find()
        },
        toolbar: ["create"],
        pageable: true,
        sortable: true,
        navigatable: true,
        resizable: true,
        reorderable: true,
        groupable: true,
        filterable: true,

    });
    $('.k-grid-add').on('click', crerateitem)
})



var deleteitem = function (e) {
    var tr = $(e.target).closest("tr");
    var id = this.dataItem(tr).id;
    kendo.confirm("Are you sure that you want delete this item?").then(function () {
        $.post('/Item/Delete', { '': id }, function () {
            $("#grid").data("kendoGrid").dataSource.read();
        });
    }, function () { });
}


function CheckNullOrEmpty(s) {
    return !s
}