
    document.addEventListener('DOMContentLoaded', function () {
        // Xử lý nút "+"
        document.querySelectorAll('.plus-cart').forEach(button => {
            button.addEventListener('click', function () {
                var input = this.parentElement.querySelector('input[type="number"]');
                var productId = input.getAttribute('data-product-id');
                var newQuantity = parseInt(input.value) + 1;
                if (newQuantity <= parseInt(input.max)) {
                    input.value = newQuantity;
                    updateCart(productId, newQuantity);
                }
            });
        });

            // Xử lý nút "-"
            document.querySelectorAll('.minus-cart').forEach(button => {
        button.addEventListener('click', function () {
            var input = this.parentElement.querySelector('input[type="number"]');
            var productId = input.getAttribute('data-product-id');
            var newQuantity = parseInt(input.value) - 1;
            if (newQuantity >= parseInt(input.min)) {
                input.value = newQuantity;
                updateCart(productId, newQuantity);
            }
        });
            });

            // Xử lý nút "Xóa"
            document.querySelectorAll('.delete-option a').forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            var productId = this.getAttribute('data-product-id');
            removeFromCart(productId);
        });
            });

    // Hàm cập nhật giỏ hàng
    function updateCart(productId, quantity) {
        fetch('/Cart/UpdateCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productId: productId, quantity: quantity })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    updateSummary(data.totalQuantity, data.totalCost);
                } else {
                    alert('Có lỗi xảy ra. Vui lòng thử lại.');
                }
            });
            }

    // Hàm xóa sản phẩm khỏi giỏ hàng
    function removeFromCart(productId) {
        fetch('/Cart/RemoveFromCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productId: productId })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Xóa sản phẩm khỏi giao diện
                    document.querySelector(`[data-product-id="${productId}"]`).closest('.cart-item').remove();
                    updateSummary(data.totalQuantity, data.totalCost);
                } else {
                    alert('Có lỗi xảy ra. Vui lòng thử lại.');
                }
            });
            }

    // Hàm cập nhật tóm tắt giỏ hàng
    function updateSummary(totalQuantity, totalCost) {
        document.querySelector('.summary-box p:nth-child(1)').textContent = totalQuantity + ' sản phẩm';
    document.querySelector('.summary-box p:nth-child(2)').innerHTML = 'Tổng cộng: ' + totalCost.toLocaleString() + ' đ <span style="font-size: 12px; color: #666;">(Chưa có cước vận chuyển)</span>';
            }
        });