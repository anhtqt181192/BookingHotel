var dataCache = null;

function bindContextMenu() {
    $('a.detail-user').click(function (e) {
        e.preventDefault();
        var id = $(e.target).data("id");
        showDetailsUser(id);
        $("#kt_modal_1").modal();
    })

    $('a.detail-user').parent().bind("contextmenu", function (e) {
        e.preventDefault();
        if (e.which == 3) {
            var $this = $(this);
            // store a callback on the trigger
            var _offset = $this.offset(),
                position = {
                    x: _offset.left + 10,
                    y: _offset.top + 10
                }
            // open the contextMenu asynchronously
            $this.find("a").contextMenu(position);
        }
    })


    $('a.detail-user').bind("contextmenu", function (e) {
        e.preventDefault();
        if (e.which == 3) {
            var $this = $(this);
            // store a callback on the trigger
            var _offset = $this.offset(),
                position = {
                    x: _offset.left + 10,
                    y: _offset.top + 10
                }
            // open the contextMenu asynchronously
            $this.contextMenu(position);
        }
    })

    $.contextMenu({
        selector: '.detail-user',
        trigger: 'none',
        callback: function (key, options) {
            var m = "clicked: " + key;
            window.console && console.log(m) || alert(m);
        },
        items: {
            "detais": { name: "Chi tiết", icon: "edit" },
            "new": { name: "Mở trong tab mới", icon: "copy" },
        }
    });

}

function GetDataTimesheets() {
    var branchId = $("#BranchId > option:selected").val();
    var fromTime = $("#FromTime").val();
    var toTime = $("#ToTime").val();
    var obj = {
        branchId: branchId,
        fromTime: fromTime,
        toTime: toTime
    };

    $.ajax({
        type: "POST",
        url: "/Admin/Timesheets/GetDataTimesheets",
        data: obj,
        success: function (data) {
            dataCache = data;
            BindDataToTable(data);
        }
    })
}


function BindDataToTable(data) {
    var html_check = "<i class='far fa-check-circle'  title='Chấm công'></i>";
    var html_unCheck = "<i class='far fa-times-circle'  title='Không chấm công'></i>";
    var html_checkLate = "<i class='fas fa-circle-notch'  title='Chấm công thiếu'></i>";
    var html = "";
    var html_thead = "";
    for (var i = 0; i < data.data_CheckIn_CheckOut.length; i++) {
        var row = data.data_CheckIn_CheckOut[i];
        html += "<tr class='border-dotted'><td rowspan='2' class='name-employee'><a class='detail-user' href='#' data-id='" + row.id + "'>" + row.username + "</a></td>";
        html += "<td  class='check-status'>Check In</td>";
        for (var j = 0; j < row.statusCheckIn.length; j++) {
            if (row.statusCheckIn[j] > 2)
                html += "<td>" + html_check + "</td>";
            else if (row.statusCheckIn[j] == 2)
                html += "<td>" + html_unCheck + "</td>";
            else
                html += "<td> -- </td>";
        }
        html += "</tr><tr><td>Check Out</td>";
        for (var k = 0; k < row.statusCheckOut.length; k++) {
            if (row.statusCheckOut[k] > 2)
                html += "<td>" + html_check + "</td>";
            else if (row.statusCheckOut[k] == 2)
                html += "<td>" + html_unCheck + "</td>";
            else
                html += "<td> -- </td>";
        }
        html += "</tr>";
    }
    html_thead += "<tr><th colspan='2'>Nhân Viên</th>";
    for (var i = 0; i < data.dayOfTimesheets.length; i++) {
        html_thead += "<th>" + data.dayOfTimesheets[i] + "</th>";
    }
    html_thead += "</tr>";
    $("#kt_table_1 thead").html(html_thead);
    $("#kt_table_1 tbody").html(html);

    bindContextMenu();
}

function showDetailsUser(id) {
    var fullDayOfTimesheets = dataCache.fullDayOfTimesheets;
    var table = $('#table-details').DataTable();
    table.clear();

    for (var i = 0; i < dataCache.data_CheckIn_CheckOut.length; i++) {
        var timeSheet = dataCache.data_CheckIn_CheckOut[i];
        if (timeSheet.id == id) {
            for (var j = 0; j < timeSheet.statusCheckIn.length; j++) {
                var obj = [fullDayOfTimesheets[j], FormatDate(timeSheet.statusCheckIn[j]), FormatDate(timeSheet.statusCheckOut[j])];
                table.row.add(obj);
            }
            table.draw();
            return;
        }
    }
}

function FormatDate(secs) {
    if (secs > 2) {
        var timeStamp = toDateTime(secs);
        var hours = timeStamp.getHours() > 10 ? timeStamp.getHours() : "0" + timeStamp.getHours();
        var min = timeStamp.getMinutes() > 10 ? timeStamp.getMinutes() : "0" + timeStamp.getMinutes();
        return hours + " : " + min;
    }
    return "--";
}

function toDateTime(secs) {
    var t = new Date(2019, 1, 1, 0, 0, 0); // Epoch
    t.setSeconds(secs);
    return t;
}

function ExportExcelFile() {
    var branchId = $("#BranchId > option:selected").val();
    var fromTime = $("#FromTime").val();
    var toTime = $("#ToTime").val();
    var obj = {
        branchId: branchId,
        fromTime: fromTime,
        toTime: toTime
    };

    var url = "/Admin/Timesheets/ExportTimeSheetsResult?" + serialize(obj);

    var win = window.open(url, '_blank');
}

serialize = function (obj) {
    var str = [];
    for (var p in obj)
        if (obj.hasOwnProperty(p)) {
            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        }
    return str.join("&");
}

function ExportPDFFile() {

}


jQuery(document).ready(function () {
    $(".datepicker").datepicker({
        language: 'vi',
        format: "dd/mm/yyyy",
        todayHighlight: true,
        autoclose: true,
        forceParse: 0,
    });

    GetDataTimesheets();

    datatable = $('#table-details').DataTable({
        ordering: false,
        searching: false,
        info: false,
        lengthChange: false,
        dom: '<"top"p>'
    })
});


