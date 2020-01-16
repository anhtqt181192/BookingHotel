function DownloadAPK() {
    $("#setup-fast-button").removeClass("kt-menu__item--open-dropdown kt-menu__item--hover")
    $("#kt_header_menu_mobile_close_btn").click()
    var loading = new KTDialog({ 'type': 'loader', 'placement': 'top center', 'message': 'Đang chuẩn bị file apk ...' });
    loading.show();
    fetch('/Services/DownloadAPK')
        .then(resp => resp.blob())
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            a.download = 'avn.apk';
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
            loading.hide();
        })
        .catch(() => alert('tải file lỗi!'));
}

$(document).ready(function () {
    var url = window.location.pathname
    var aThis = $("a.kt-menu__link[href='" + window.location.pathname + "']");
    var target = aThis.closest(".kt-menu__item");
    var i = 0;
    do {
        target.addClass("kt-menu__item--open");
        target = target.parent().closest(".kt-menu__item");
        i++;
    }
    while (target.length > 0 && i < 5)
})