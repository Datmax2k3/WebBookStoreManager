document.addEventListener('DOMContentLoaded', function () {
    // Lấy các phần tử
    const minusBtn = document.querySelector('.quantity-selector .minus');
    const plusBtn = document.querySelector('.quantity-selector .plus');
    const qtyInput = document.querySelector('.quantity-selector input[type="number"]');
    const addToCartButton = document.querySelector('.add-to-cart');

    // Sự kiện bấm nút "-"
    minusBtn.addEventListener('click', function () {
        let currentValue = parseInt(qtyInput.value) || 0;
        const minValue = parseInt(qtyInput.min) || 1; // nếu không có min thì mặc định là 1
        if (currentValue > minValue) {
            currentValue--;
            qtyInput.value = currentValue;
        }
    });

    // Sự kiện bấm nút "+"
    plusBtn.addEventListener('click', function () {
        let currentValue = parseInt(qtyInput.value) || 0;
        const maxValue = parseInt(qtyInput.max) || 9999; // nếu không có max thì mặc định là 9999
        if (currentValue < maxValue) {
            currentValue++;
            qtyInput.value = currentValue;
        }
    });

    // Sự kiện bấm nút "Thêm vào giỏ hàng"
    addToCartButton.addEventListener('click', function () {
        const productId = this.getAttribute('data-product-id');
        const quantity = parseInt(qtyInput.value) || 1; // Lấy giá trị từ ô input

        // Gửi yêu cầu AJAX đến CartController/AddToCart
        fetch('/Cart/AddToCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ productId: productId, quantity: quantity })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Thành công -> chuyển hướng giỏ hàng
                    window.location.href = '/Cart/Index';
                }
                else if (data.redirectTo) {
                    // Nếu server trả về redirectTo -> chuyển hướng
                    window.location.href = data.redirectTo;
                }
                else {
                    // Hiển thị message lỗi
                    alert(data.message || "Đã có lỗi xảy ra!");
                }
            })
            .catch(err => {
                console.error(err);
                alert("Lỗi kết nối!");
            });
    });
});