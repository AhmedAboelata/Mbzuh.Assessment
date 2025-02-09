    var baseUrl = 'https://localhost:7091/api';
    var table;

    $(function () {
        table = $('#tblBooks').DataTable({
            "searching": false,
            "pageLength": 5,
            "serverSide": true,
            "processing": true,
            "rowId": "id",
            "filter": true,
            "bSort": false,
            "lengthMenu": [[5, 10, 20], [5, 10, 20]],
            "ajax": {
                url: baseUrl + "/Book/Get",
                type: 'GET',
                datatype: "json",
                data: function (d) {
                    d.SearchText = $("#searchText").val();
                },
                complete: function (data) {
                    $("#loader").hide();
                },
            },
            "language": {
                searchPlaceholder: 'Search by Author or Genre'
            },
            "columns": [
                { "data": "id", "visible": false },
                { "data": "title", name: "Title" },
                { "data": "author", name: "Author" },
                { "data": "isbn", name: "ISBN" },
                { "data": "publicationYear", name: "Publication Year" },
                { "data": "genre", name: "Genre" },
                {
                    sortable: false, "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-success" onclick="openEditModal(' + "'" + row.id + "'" + ')">Edit</button>'
                            + '<button type="button" class="btn btn-danger mx-2" onclick="deleteBook(' + "'" + row.id + "'" + ')">Delete</button>';
                    }
                }
            ]
        });
    });

    function ReloadGrid() {
        table.ajax.reload();
    }

    function openCreateModal() {
        $("#bookId").val("");
        $("#title").val("");
        $("#author").val("");
        $("#isbn").val("");
        $("#publicationYear").val("");
        $("#genre").html
        FillGenreDropDown();
        $("#bookModal").modal("show");
    }

    function FillGenreDropDown(selectedOptionText, isOpenModal) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: baseUrl + '/Genre/GetAll',
            success: function (response) {
                if (response.success) {
                    var str = '<option value="-1"' + (selectedOptionText == null ? ' selected' : '') + '>Please Select</option>';
                    for (var i = 0; i < response.data.length; i++)
                        str += '<option value="' + response.data[i].id + '"' + (selectedOptionText == response.data[i].name ? ' selected' : '') + '>' + response.data[i].name + '</option>';
                    $("#genre").html(str);
                    if (isOpenModal)
                        $("#bookModal").modal("show");
                } else
                    alert(response.message);
            },
            error: function (response) { alert(response.responseJSON.message); }
        });
    }

    function openEditModal(id) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: baseUrl + '/Book/GetById?Id=' + id,
            success: function (response) {
                if (response.success) {
                    $("#bookId").val(response.data.id);
                    $("#title").val(response.data.title);
                    $("#author").val(response.data.author);
                    $("#isbn").val(response.data.isbn);
                    $("#publicationYear").val(response.data.publicationYear);
                    FillGenreDropDown(response.data.genre, true);
                } else
                    alert(response.message);
            },
            error: function (response) { alert(response.responseJSON.message); }
        });
    }

    function saveBook() {
        if ($("#title").val().trim() == '')
    return alert('Title should have value.');
    if ($("#author").val().trim() == '')
    return alert('Author should have value.');
    if ($("#isbn").val().trim() == '')
    return alert('ISBN should have value.');
    if ($("#isbn").val().trim().length < 10 || $("#isbn").val().trim().length > 13)
    return alert('ISBN length should be between 10:13 charachter.');
    if ($("#publicationYear").val().trim() == '')
    return alert('Publication Year should have value.');
    if ($("#publicationYear").val() < 1900 || $("#publicationYear").val() > 9999)
    return alert('Publication Year should be between 1900:9999');
    if ($("#genre").val() == null || $("#genre").val() == "-1" || $("#genre")[0].selectedIndex == 0)
    return alert('Please choose genre.');

    var book = {
        title: $("#title").val().trim(),
    author: $("#author").val().trim(),
    iSBN: $("#isbn").val().trim(),
    publicationYear: $("#publicationYear").val(),
    genre: $("#genre option:selected").text()
        };
    var url = "/Book/Create";
    if ($("#bookId").val() != null && $("#bookId").val() != "") {
        book.id = $("#bookId").val();
    url = "/Book/Update";
        }

    $.ajax({
        type: 'POST',
    contentType: 'application/json; charset=utf-8',
    url: baseUrl + url,
    data: JSON.stringify(book),
    success: function(response) {
                if (response.success) {
        alert('Save Done Successfully');
    $("#bookModal").modal("hide");
    ReloadGrid();
                } else {
        alert(response.message);
    $("#bookModal").modal("hide");
                }
            },
    error: function(response) {alert(response.responseJSON.message); }
        });
    }

    function deleteBook(id) {
        if (confirm("Are you sure you want to delete this book?")) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: baseUrl + '/Book/Delete',
            data: JSON.stringify({ id: id }),
            success: function (response) {
                if (response.success) {
                    alert('Delete Done Successfully');
                    ReloadGrid();
                }
                else
                    alert(response.message);
            },
            error: function (response) { alert(response.responseJSON.message); }
        });
        }
    }
