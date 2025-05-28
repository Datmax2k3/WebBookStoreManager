document.addEventListener('DOMContentLoaded', function () {
    // Lấy các phần tử cho trang ProductDetail
    const minusBtn = document.querySelector('.quantity-selector .minus');
    const plusBtn = document.querySelector('.quantity-selector .plus');
    const qtyInput = document.querySelector('.quantity-selector input[type="number"]');

    // Sự kiện cho quantity selector (chỉ có trên trang ProductDetail)
    /*if (minusBtn && plusBtn && qtyInput) {
        // Sự kiện bấm nút "-"
        minusBtn.addEventListener('click', function () {
            let currentValue = parseInt(qtyInput.value) || 0;
            const minValue = parseInt(qtyInput.min) || 1;
            if (currentValue > minValue) {
                currentValue--;
                qtyInput.value = currentValue;
            }
        });

        // Sự kiện bấm nút "+"
        plusBtn.addEventListener('click', function () {
            let currentValue = parseInt(qtyInput.value) || 0;
            const maxValue = parseInt(qtyInput.max) || 9999;
            if (currentValue < maxValue) {
                currentValue++;
                qtyInput.value = currentValue;
            }
        });
    }*/

    document.addEventListener('click', function (e) {
        // Nếu click vào nút có class 'add-to-cart'
        const btn = e.target.closest('.add-to-cart');
        if (!btn) return;

        e.preventDefault();

        // Lấy thông tin sản phẩm
        const productId = btn.getAttribute('data-product-id');
        let quantity = 1;
        // Nếu có input số lượng (trên ProductDetail) thì lấy giá trị đó
        const qtyInput = document.querySelector('.quantity-selector input[type="number"]');
        if (qtyInput) {
            quantity = parseInt(qtyInput.value, 10) || 1;
        }

        // Gửi AJAX
        fetch('/Cart/AddToCart', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ productId, quantity })
        })
            .then(r => r.json())
            .then(data => {
                if (data.success) {
                    // 1. Cập nhật badge số lượng giỏ hàng ở header
                    const cartQty = document.getElementById('cart-quantity');
                    if (cartQty) {
                        cartQty.textContent = `(${data.totalQuantity})`;
                    }
                    // 2. Hiển thị toast thông báo
                    showCartToast(`Đã thêm <strong>${data.productName}</strong> vào giỏ hàng!`);
                }
                else if (data.redirectTo) {
                    // chưa login / cần profile
                    window.location.href = data.redirectTo;
                }
                else {
                    showCartToast(data.message || 'Không thêm được sản phẩm.', 'error');
                }
            })
            .catch(() => {
                showCartToast('Lỗi kết nối.', 'error');
            });
    });

    // Hàm hiển thị toast
    function showCartToast(htmlMessage, type = 'success') {
        const toast = document.createElement('div');
        toast.className = `cart-toast ${type}`;
        toast.innerHTML = htmlMessage;
        document.body.appendChild(toast);

        // Định vị ngay trên icon giỏ hàng
        const icon = document.getElementById('cart-icon');
        if (icon) {
            const rect = icon.getBoundingClientRect();
            toast.style.position = 'absolute';
            toast.style.top = `${rect.top + 20 - toast.offsetHeight}px`;
            toast.style.left = `${rect.left + (icon.offsetWidth - toast.offsetWidth) / 2}px`;
            toast.style.zIndex = 10000;
        }

        // Ẩn sau 2.5s
        setTimeout(() => {
            toast.remove();
        }, 2500);
    }
});