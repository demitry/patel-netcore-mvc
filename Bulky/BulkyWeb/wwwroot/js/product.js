$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'author', "width": "20%" },
            { data: 'isbn', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "15%" }
        ]
    });
}

