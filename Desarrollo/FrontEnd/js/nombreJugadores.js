// Variables globales
let currentPlayerIndex = 1;
let totalPlayersCount = 4; // Por defecto 4, pero se puede cambiar desde otra pantalla
let playerNames = [];

// Elementos del DOM
const playerInput = document.getElementById('playerNameInput');
const nextBtn = document.getElementById('nextBtn');
const currentPlayerSpan = document.getElementById('currentPlayer');
const totalPlayersSpan = document.getElementById('totalPlayers');
const progressFill = document.getElementById('progressFill');
const btnText = document.getElementById('btnText');

// Inicializar la aplicación
function initializeApp() {
    // Verificar si hay parámetros en la URL para el número de jugadores
    const urlParams = new URLSearchParams(window.location.search);
    const playersFromUrl = urlParams.get('players');
    
    if (playersFromUrl && !isNaN(playersFromUrl)) {
        totalPlayersCount = parseInt(playersFromUrl);
    }
    
    updateDisplay();
    updateProgress();
    playerInput.focus();
}

// Actualizar la pantalla
function updateDisplay() {
    currentPlayerSpan.textContent = `Jugador ${currentPlayerIndex}`;
    totalPlayersSpan.textContent = totalPlayersCount;
    playerInput.placeholder = `Ingresa el nombre del Jugador ${currentPlayerIndex}`;
    
    // Cambiar texto del botón en el último jugador
    if (currentPlayerIndex === totalPlayersCount) {
        btnText.textContent = 'Finalizar';
    } else {
        btnText.textContent = 'Siguiente';
    }
}

// Actualizar barra de progreso
function updateProgress() {
    const progressPercentage = (currentPlayerIndex / totalPlayersCount) * 100;
    progressFill.style.width = `${progressPercentage}%`;
}

// Función principal para avanzar al siguiente jugador
function nextPlayer() {
    const playerName = playerInput.value.trim();
    
    // Validar que el nombre no esté vacío
    if (playerName === '') {
        showError('Por favor ingresa un nombre');
        return;
    }
    
    // Validar que el nombre no se repita
    if (playerNames.includes(playerName.toLowerCase())) {
        showError('Este nombre ya existe, elige otro');
        return;
    }
    
    // Guardar el nombre del jugador
    playerNames.push(playerName.toLowerCase());
    
    // Mostrar confirmación
    showSuccess(`¡${playerName} agregado!`);
    
    // Verificar si es el último jugador
    if (currentPlayerIndex === totalPlayersCount) {
        // Terminar configuración
        finishPlayerSetup();
        return;
    }
    
    // Avanzar al siguiente jugador
    currentPlayerIndex++;
    updateDisplay();
    updateProgress();
    
    // Limpiar input y enfocar
    playerInput.value = '';
    playerInput.focus();
}

// Finalizar configuración de jugadores
function finishPlayerSetup() {
    // Guardar nombres en localStorage para usar en otras pantallas
    const finalNames = playerNames.map((name, index) => {
        return name.charAt(0).toUpperCase() + name.slice(1);
    });
    
    localStorage.setItem('playerNames', JSON.stringify(finalNames));
    localStorage.setItem('totalPlayers', totalPlayersCount.toString());
    
    // Mostrar mensaje de finalización
    showSuccess('¡Configuración completa!');
    
    // Redirigir a la siguiente pantalla después de 2 segundos
    setTimeout(() => {
        // Aquí puedes redirigir a la pantalla del juego
        window.location.href = 'lobby.html';
        alert(`¡Configuración completa!\n\nJugadores: ${finalNames.join(', ')}\n\n¡Listos para jugar!`);
    }, 2000);
}

// Mostrar mensaje de error
function showError(message) {
    playerInput.style.borderColor = '#e74c3c';
    playerInput.style.backgroundColor = 'rgba(231, 76, 60, 0.1)';
    
    // Crear elemento de error si no existe
    let errorMsg = document.querySelector('.error-message');
    if (!errorMsg) {
        errorMsg = document.createElement('div');
        errorMsg.className = 'error-message';
        errorMsg.style.cssText = `
            color: #e74c3c;
            font-size: 1.1em;
            font-weight: bold;
            margin-top: 10px;
            text-align: center;
            text-shadow: 1px 1px 2px rgba(0,0,0,0.5);
        `;
        document.querySelector('.player-input-container').appendChild(errorMsg);
    }
    
    errorMsg.textContent = message;
    
    // Remover error después de 3 segundos
    setTimeout(() => {
        playerInput.style.borderColor = '#bdc3c7';
        playerInput.style.backgroundColor = 'rgba(200, 200, 200, 0.9)';
        if (errorMsg) {
            errorMsg.remove();
        }
    }, 3000);
    
    // Shake animation
    playerInput.style.animation = 'shake 0.5s ease-in-out';
    setTimeout(() => {
        playerInput.style.animation = '';
    }, 500);
}

// Mostrar mensaje de éxito
function showSuccess(message) {
    playerInput.style.borderColor = '#27ae60';
    playerInput.style.backgroundColor = 'rgba(39, 174, 96, 0.1)';
    
    // Crear elemento de éxito si no existe
    let successMsg = document.querySelector('.success-message');
    if (!successMsg) {
        successMsg = document.createElement('div');
        successMsg.className = 'success-message';
        successMsg.style.cssText = `
            color: #27ae60;
            font-size: 1.1em;
            font-weight: bold;
            margin-top: 10px;
            text-align: center;
            text-shadow: 1px 1px 2px rgba(0,0,0,0.5);
        `;
        document.querySelector('.player-input-container').appendChild(successMsg);
    }
    
    successMsg.textContent = message;
    
    // Remover mensaje después de 1.5 segundos
    setTimeout(() => {
        playerInput.style.borderColor = '#bdc3c7';
        playerInput.style.backgroundColor = 'rgba(200, 200, 200, 0.9)';
        if (successMsg) {
            successMsg.remove();
        }
    }, 1500);
}

// Eventos del teclado
playerInput.addEventListener('keydown', function(e) {
    if (e.key === 'Enter') {
        nextPlayer();
    }
});

// Validación en tiempo real
playerInput.addEventListener('input', function() {
    const value = this.value.trim();
    
    // Habilitar/deshabilitar botón
    if (value === '') {
        nextBtn.disabled = true;
    } else {
        nextBtn.disabled = false;
    }
    
    // Validar caracteres especiales
    const validName = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(value);
    if (value !== '' && !validName) {
        this.style.borderColor = '#f39c12';
    } else {
        this.style.borderColor = '#bdc3c7';
    }
});

// Función para establecer número de jugadores (desde otra pantalla)
function setTotalPlayers(count) {
    totalPlayersCount = count;
    updateDisplay();
    updateProgress();
}

// Función para obtener nombres de jugadores (para usar en otras pantallas)
function getPlayerNames() {
    return JSON.parse(localStorage.getItem('playerNames') || '[]');
}

// Función para obtener total de jugadores (para usar en otras pantallas)
function getTotalPlayers() {
    return parseInt(localStorage.getItem('totalPlayers') || '4');
}

// Agregar animación shake al CSS dinámicamente
const shakeStyle = document.createElement('style');
shakeStyle.textContent = `
    @keyframes shake {
        0%, 100% { transform: translateX(0); }
        10%, 30%, 50%, 70%, 90% { transform: translateX(-5px); }
        20%, 40%, 60%, 80% { transform: translateX(5px); }
    }
`;
document.head.appendChild(shakeStyle);

// Inicializar cuando se carga la página
document.addEventListener('DOMContentLoaded', initializeApp);

// Función para reiniciar (útil para desarrollo/testing)
function resetPlayerSetup() {
    currentPlayerIndex = 1;
    playerNames = [];
    updateDisplay();
    updateProgress();
    playerInput.value = '';
    playerInput.focus();
    localStorage.removeItem('playerNames');
    localStorage.removeItem('totalPlayers');
}

// Funciones para navegar entre pantallas (para integrar con otras pantallas)
function goToPreviousScreen() {
    // Implementar navegación hacia atrás
    window.history.back();
}

function goToGameScreen() {
    // Implementar navegación hacia el juego
    window.location.href = 'game.html';
}