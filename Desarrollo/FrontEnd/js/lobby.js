// Avatares disponibles
const avatars = [
    {
        id: 1,
        name: 'Pollito',
        image: '+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiM4QjQ1MTMiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iIzAwMCIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9Ijc1IiByeD0iMTIiIHJ5PSI2IiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iMzAiIGN5PSIzMCIgcj0iMTUiIGZpbGw9IiM4QjQ1MTMiLz48Y2lyY2xlIGN4PSI5MCIgY3k9IjMwIiByPSIxNSIgZmlsbD0iIzhCNDUxMyIvPjwvc3ZnPg=='
    },
    {
        id: 3,
        name: 'Perrito',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiM2OTc2OEEiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iIzAwMCIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9Ijc1IiByeD0iMTUiIHJ5PSI4IiBmaWxsPSIjRkY2OUI0Ii8+PHBvbHlnb24gcG9pbnRzPSI0MCwyNSA1MCwxNSA2MCwyNSA3MCwxNSA4MCwyNSA3NSwyOCA0NSwyOCIgZmlsbD0iI0ZGRiIvPjwvc3ZnPg=='
    },
    {
        id: 4,
        name: 'Gatito',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiNGRkYiLz48Y2lyY2xlIGN4PSI2MCIgY3k9IjYwIiByPSI1NSIgZmlsbD0iI0Y4RjlGQSIgc3Ryb2tlPSIjMDAwIiBzdHJva2Utd2lkdGg9IjIiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iIzAwMCIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9Ijc1IiByeD0iMTAiIHJ5PSI1IiBmaWxsPSIjRkY2OUI0Ii8+PHBvbHlnb24gcG9pbnRzPSI0NSwyMCA1NSwxMCA2NSwyMCIgZmlsbD0iI0ZGNjlCNCIvPjxwb2x5Z29uIHBvaW50cz0iNzUsMjAgNjUsMTAgNTUsMjAiIGZpbGw9IiNGRjY5QjQiLz48L3N2Zz4='
    },
    {
        id: 5,
        name: 'Dinosaurio',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiNFOTFFK0MiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjRkZGIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iI0ZGRiIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9Ijc1IiByeD0iMjAiIHJ5PSIxMCIgZmlsbD0iI0ZGRiIvPjxyZWN0IHg9IjUwIiB5PSIxNSIgd2lkdGg9IjgiIGhlaWdodD0iMTUiIGZpbGw9IiMyN0FFNjAiIHJ4PSI0Ii8+PHJlY3QgeD0iNjIiIHk9IjEwIiB3aWR0aD0iNiIgaGVpZ2h0PSIyMCIgZmlsbD0iIzI3QUU2MCIgcng9IjMiLz48L3N2Zz4='
    },
    {
        id: 6,
        name: 'Cachorro',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiNEQUE1MjAiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iIzAwMCIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9Ijc1IiByeD0iMTUiIHJ5PSI4IiBmaWxsPSIjMDAwIi8+PGVsbGlwc2UgY3g9IjMwIiBjeT0iNDAiIHJ4PSIxMCIgcnk9IjE1IiBmaWxsPSIjREFBNTIwIiByb3RhdGU9Ii0zMCIvPjxlbGxpcHNlIGN4PSI5MCIgY3k9IjQwIiByeD0iMTAiIHJ5PSIxNSIgZmlsbD0iI0RBQTUyMCIgcm90YXRlPSIzMCIvPjwvc3ZnPg=='
    },
    {
        id: 7,
        name: 'León',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiM4QjQ1MTMiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjUwIiByPSI1IiBmaWxsPSIjRkZGIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI1MCIgcj0iNSIgZmlsbD0iI0ZGRiIvPjxlbGxpcHNlIGN4PSI2MCIgY3k9IjgwIiByeD0iMTUiIHJ5PSI4IiBmaWxsPSIjRkZGIi8+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNDAiIGZpbGw9Im5vbmUiIHN0cm9rZT0iIzY1MzcxRCIgc3Ryb2tlLXdpZHRoPSI4Ii8+PC9zdmc+'
    },
    {
        id: 8,
        name: 'Robot',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiMyNzAzOUQiLz48Y2lyY2xlIGN4PSI0NSIgY3k9IjQ1IiByPSI1IiBmaWxsPSIjRkZEMjAwIi8+PGNpcmNsZSBjeD0iNzUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iI0ZGRDIwMCIvPjxyZWN0IHg9IjQ1IiB5PSI3MCIgd2lkdGg9IjMwIiBoZWlnaHQ9IjEwIiBmaWxsPSIjRkZEMjAwIiByeD0iNSIvPjxyZWN0IHg9IjIwIiB5PSIyMCIgd2lkdGg9IjgwIiBoZWlnaHQ9IjE1IiBmaWxsPSIjRkZEMjAwIiByeD0iNyIvPjwvc3ZnPg=='
    },
    {
        id: 9,
        name: 'Panda',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiNGRkYiLz48Y2lyY2xlIGN4PSIzNSIgY3k9IjM1IiByPSIyMCIgZmlsbD0iIzAwMCIvPjxjaXJjbGUgY3g9Ijg1IiBjeT0iMzUiIHI9IjIwIiBmaWxsPSIjMDAwIi8+PGNpcmNsZSBjeD0iNDUiIGN5PSI1MCIgcj0iNSIgZmlsbD0iIzAwMCIvPjxjaXJjbGUgY3g9Ijc1IiBjeT0iNTAiIHI9IjUiIGZpbGw9IiMwMDAiLz48ZWxsaXBzZSBjeD0iNjAiIGN5PSI3NSIgcng9IjEyIiByeT0iNiIgZmlsbD0iIzAwMCIvPjwvc3ZnPg=='
    },
    {
        id: 10,
        name: 'Conejo',
        image: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwIiBoZWlnaHQ9IjEyMCIgdmlld0JveD0iMCAwIDEyMCAxMjAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iNjAiIGN5PSI2MCIgcj0iNjAiIGZpbGw9IiNGRkU0RTEiLz48ZWxsaXBzZSBjeD0iNDUiIGN5PSIyNSIgcng9IjgiIHJ5PSIyNSIgZmlsbD0iI0ZGRTRFMSIvPjxlbGxpcHNlIGN4PSI3NSIgY3k9IjI1IiByeD0iOCIgcnk9IjI1IiBmaWxsPSIjRkZFNEUxIi8+PGNpcmNsZSBjeD0iNDUiIGN5PSI0NSIgcj0iNSIgZmlsbD0iIzAwMCIvPjxjaXJjbGUgY3g9Ijc1IiBjeT0iNDUiIHI9IjUiIGZpbGw9IiMwMDAiLz48ZWxsaXBzZSBjeD0iNjAiIGN5PSI3NSIgcng9IjE1IiByeT0iOCIgZmlsbD0iI0ZGNjlCNCIvPjwvc3ZnPg=='
    }
];

// Variables globales
let players = [];
let numberOfPlayers = 4;
let currentEditingPlayer = null;

// Función para obtener avatares aleatorios únicos
function getRandomAvatars(count) {
    const shuffled = [...avatars].sort(() => 0.5 - Math.random());
    return shuffled.slice(0, count);
}

// Función para obtener el número de jugadores
function getNumberOfPlayers() {
    const urlParams = new URLSearchParams(window.location.search);
    const playersParam = urlParams.get('players');
    
    if (playersParam && !isNaN(playersParam) && playersParam >= 2 && playersParam <= 8) {
        return parseInt(playersParam);
    }
    
    const userChoice = prompt('¿Cuántos jugadores van a jugar? (2-8)', '4');
    const num = parseInt(userChoice);
    
    if (isNaN(num) || num < 2 || num > 8) {
        return 4;
    }
    
    return num;
}

// Función para asignar avatares automáticamente
function assignRandomAvatars() {
    const selectedAvatars = getRandomAvatars(numberOfPlayers);
    players = selectedAvatars.map((avatar, index) => ({
        id: index + 1,
        name: `Jugador ${index + 1}`,
        avatar: avatar
    }));
}

// Función para crear una tarjeta de jugador
function createPlayerCard(player) {
    const card = document.createElement('div');
    card.className = 'player-card';
    card.dataset.playerId = player.id;
    
    card.innerHTML = `
        <div class="change-indicator">✎</div>
        <div class="player-avatar">
            <img src="${player.avatar.image}" alt="${player.avatar.name}" />
        </div>
        <div class="player-name">${player.name}</div>
    `;
    
    // Agregar animación de entrada escalonada
    card.style.animation = `fadeInUp 0.6s ease forwards`;
    card.style.animationDelay = `${player.id * 0.1}s`;
    card.style.opacity = '0';
    
    // Evento para cambiar avatar
    card.addEventListener('click', () => openAvatarModal(player));
    
    return card;
}

// Función para abrir el modal de selección de avatar
function openAvatarModal(player) {
    currentEditingPlayer = player;
    const modal = document.getElementById('avatarModal');
    const avatarGrid = document.getElementById('avatarGrid');
    
    // Limpiar grid
    avatarGrid.innerHTML = '';
    
    // Crear opciones de avatar
    avatars.forEach(avatar => {
        const option = document.createElement('div');
        option.className = 'avatar-option';
        option.dataset.avatarId = avatar.id;
        
        // Marcar si es el avatar actual
        if (player.avatar.id === avatar.id) {
            option.classList.add('selected');
        }
        
        option.innerHTML = `<img src="${avatar.image}" alt="${avatar.name}" />`;
        
        // Evento de selección
        option.addEventListener('click', () => selectAvatar(avatar));
        
        avatarGrid.appendChild(option);
    });
    
    // Mostrar modal
    modal.classList.add('active');
}

// Función para seleccionar un avatar
function selectAvatar(avatar) {
    if (currentEditingPlayer) {
        // Actualizar el avatar del jugador
        currentEditingPlayer.avatar = avatar;
        
        // Actualizar la vista
        renderPlayers();
        
        // Cerrar modal
        closeAvatarModal();
        
        // Mostrar notificación
        showNotification(`Avatar actualizado para ${currentEditingPlayer.name}`);
    }
}

// Función para cerrar el modal
function closeAvatarModal() {
    const modal = document.getElementById('avatarModal');
    modal.classList.remove('active');
    currentEditingPlayer = null;
}

// Función para renderizar jugadores
function renderPlayers() {
    const container = document.getElementById('playersContainer');
    container.innerHTML = '';
    
    // Agregar clase según número de jugadores
    container.className = `players-container players-${numberOfPlayers}`;
    
    // Crear tarjetas
    players.forEach(player => {
        const card = createPlayerCard(player);
        container.appendChild(card);
    });
}

// Función para mostrar notificaciones
function showNotification(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = 'notification';
    notification.textContent = message;
    
    const bgColor = type === 'success' ? 
        'linear-gradient(145deg, #27ae60, #229954)' : 
        'linear-gradient(145deg, #f39c12, #e67e22)';
    
    notification.style.cssText = `
        position: fixed;
        top: 100px;
        left: 50%;
        transform: translateX(-50%);
        background: ${bgColor};
        color: white;
        padding: 15px 25px;
        border-radius: 10px;
        font-weight: bold;
        font-size: 16px;
        z-index: 1001;
        box-shadow: 0 8px 25px rgba(0,0,0,0.3);
        animation: notificationSlide 0.5s ease;
    `;
    
    // Agregar estilos de animación si no existen
    if (!document.querySelector('#notificationStyles')) {
        const style = document.createElement('style');
        style.id = 'notificationStyles';
        style.textContent = `
            @keyframes notificationSlide {
                0% { transform: translateX(-50%) translateY(-20px); opacity: 0; }
                100% { transform: translateX(-50%) translateY(0); opacity: 1; }
            }
        `;
        document.head.appendChild(style);
    }
    
    document.body.appendChild(notification);
    
    // Remover después de 3 segundos
    setTimeout(() => {
        notification.style.animation = 'notificationSlide 0.3s ease reverse';
        setTimeout(() => {
            if (notification.parentNode) {
                notification.parentNode.removeChild(notification);
            }
        }, 300);
    }, 3000);
}

// Función para iniciar el juego
function startGame() {
    // Mostrar confirmación
    const playerNames = players.map(p => p.name).join(', ');
    const confirmed = confirm(`¿Iniciar juego con: ${playerNames}?`);
    
    if (confirmed) {
        // Guardar configuración de jugadores
        console.log('Jugadores configurados:', players);
        
        // Mostrar mensaje de éxito
        showNotification('¡Iniciando juego!', 'success');
        
        // Simular transición al juego
        setTimeout(() => {
            // Aquí normalmente navegarías al juego
            // window.location.href = 'game.html?players=' + encodeURIComponent(JSON.stringify(players));
            console.log('Navegando al juego con configuración:', players);
        }, 1500);
    }
}

// Función para cerrar/salir
function closeGame() {
    const confirmed = confirm('¿Estás seguro de que quieres salir?');
    if (confirmed) {
        window.history.back();
    }
}

// Función de inicialización
function init() {
    // Obtener número de jugadores
    numberOfPlayers = getNumberOfPlayers();
    
    // Asignar avatares automáticamente
    assignRandomAvatars();
    
    // Renderizar jugadores
    renderPlayers();
    
    // Configurar event listeners
    document.getElementById('btnStart').addEventListener('click', startGame);
    document.querySelector('.btn-close').addEventListener('click', closeGame);
    document.getElementById('modalClose').addEventListener('click', closeAvatarModal);
    
    // Cerrar modal al hacer clic fuera
    document.getElementById('avatarModal').addEventListener('click', (e) => {
        if (e.target.id === 'avatarModal') {
            closeAvatarModal();
        }
    });
    
    // Mostrar mensaje de bienvenida
    setTimeout(() => {
        showNotification('Avatares asignados automáticamente. ¡Toca cualquier jugador para cambiarlo!');
    }, 1000);
}

// Funciones de utilidad para testing
window.testFunctions = {
    setNumberOfPlayers: (num) => {
        if (num >= 2 && num <= 8) {
            numberOfPlayers = num;
            assignRandomAvatars();
            renderPlayers();
            showNotification(`Configurado para ${num} jugadores`);
        }
    },
    getPlayers: () => players,
    reassignAvatars: () => {
        assignRandomAvatars();
        renderPlayers();
        showNotification('Avatares reasignados aleatoriamente');
    }
};

// Inicializar cuando se carga el DOM
document.addEventListener('DOMContentLoaded', init);