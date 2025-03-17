document.addEventListener("DOMContentLoaded", function () {
    var collapseMenu = document.getElementById("collapseEmployeeMenu");

    // Khởi tạo collapse không toggle tự động khi trang load
    var bsCollapse = new bootstrap.Collapse(collapseMenu, {
        toggle: false
    });

    // Kiểm tra trạng thái lưu trong localStorage và mở collapse nếu cần
    if (localStorage.getItem("employeeMenuOpen") === "true") {
        bsCollapse.show();
    }

    // Khi collapse được mở, lưu trạng thái "true"
    collapseMenu.addEventListener("shown.bs.collapse", function () {
        localStorage.setItem("employeeMenuOpen", "true");
    });

    // Khi collapse bị đóng, lưu trạng thái "false"
    collapseMenu.addEventListener("hidden.bs.collapse", function () {
        localStorage.setItem("employeeMenuOpen", "false");
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var sidebarItems = document.querySelectorAll('.list-reset li');

    sidebarItems.forEach(function (item) {
        item.addEventListener('click', function () {
            // Xóa lớp 'active' khỏi tất cả các mục
            sidebarItems.forEach(function (el) {
                el.classList.remove('active');
            });

            // Thêm lớp 'active' vào mục được nhấn
            this.classList.add('active');
        });
    });
});


document.addEventListener("DOMContentLoaded", function () {
    var sidebarLinks = document.querySelectorAll("aside ul li a");

    // Lấy giá trị từ localStorage nếu có
    var activeLink = localStorage.getItem("activeSidebar");

    if (activeLink) {
        sidebarLinks.forEach(function (link) {
            if (link.getAttribute("href") === activeLink) {
                link.classList.add("active-sidebar");
            }
        });
    }

    sidebarLinks.forEach(function (link) {
        link.addEventListener("click", function () {
            // Xóa lớp active khỏi tất cả các mục
            sidebarLinks.forEach(function (el) {
                el.classList.remove("active-sidebar");
            });

            // Thêm lớp active vào mục được nhấn
            this.classList.add("active-sidebar");

            // Lưu trạng thái vào localStorage
            localStorage.setItem("activeSidebar", this.getAttribute("href"));
        });
    });
});

