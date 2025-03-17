document.addEventListener('DOMContentLoaded', function () {
    const chatBubble = document.getElementById('chatBubble');
    const chatBox = document.getElementById('chatBox');
    const chatCloseBtn = document.getElementById('chatCloseBtn');
    const chatSendBtn = document.getElementById('chatSendBtn');
    const chatInput = document.getElementById('chatInput');
    const chatMessages = document.getElementById('chatMessages');

    // Bật/tắt khung chat
    chatBubble.addEventListener('click', function () {
        chatBox.style.display = 'flex';
    });
    chatCloseBtn.addEventListener('click', function () {
        chatBox.style.display = 'none';
    });

    // Hàm thêm tin nhắn vào khung
    function addMessage(role, text) {
        const msgDiv = document.createElement('div');
        msgDiv.classList.add('chat-message', role);
        msgDiv.textContent = text;
        chatMessages.appendChild(msgDiv);
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }

    // Gửi tin nhắn khi nhấn nút
    chatSendBtn.addEventListener('click', sendMessage);
    // Gửi tin nhắn khi nhấn Enter
    chatInput.addEventListener('keydown', function (e) {
        if (e.key === 'Enter') {
            e.preventDefault();
            sendMessage();
        }
    });

    function sendMessage() {
        const userMessage = chatInput.value.trim();
        if (!userMessage) return;

        // Hiển thị tin nhắn người dùng
        addMessage('user', userMessage);
        chatInput.value = '';

        // Gửi request đến API Dialogflow (đảm bảo đường dẫn khớp với controller)
        fetch('/api/Dialogflow', {  // <-- Sửa ở đây: dùng /api/Dialogflow thay vì /api/chat
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ message: userMessage })
        })
            .then(response => response.json())
            .then(data => {
                // data.reply là câu trả lời từ AI
                addMessage('ai', data.reply);
            })
            .catch(err => {
                console.error(err);
                addMessage('ai', "Xin lỗi, có lỗi xảy ra.");
            });
    }
});
