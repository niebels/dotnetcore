var dataTable;

$(document).ready(function() {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/BookList/Edit?id=${data}" class="btn btn-success text-white" style="width: 100px;">Edit</a>&nbsp;
                            <a onclick=Delete('/api/book?id='+${data}) class="btn btn-danger text-white" style="width: 100px;">Delete</a>
                        </div>
                    `
                },
                "width": "40%;"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width" : "100%"
    });
}

function Delete(url) {
    swal({
        title: "I dare you...",
        text: "I DOUBLE dare you, mothafokka!",
        icon: "warning",
        buttons: true,
        dangerMode : true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}