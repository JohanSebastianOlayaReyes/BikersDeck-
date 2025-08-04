// Efecto parallax sutil para el fondo
function initializeParallaxEffect() {
    let mouseX = 0;
    let mouseY = 0;
    
    document.addEventListener('mousemove', (e) => {
        mouseX = (e.clientX / window.innerWidth) * 100;
        mouseY = (e.clientY / window.innerHeight) * 100;
        
        const background = document.querySelector('.background-pattern');
        background.style.backgroundPosition = `
            ${mouseX * 0.1}px ${mouseY * 0.1}px,
            ${mouseX * 0.05}px ${mouseY * 0.05}px,
            ${mouseX * 0.02}px ${mouseY * 0.02}px
        `;
    });
}

// Animación de entrada secuencial
function initializeEntryAnimation() {
    const elements = [
        { selector: '.logo-container', delay: 0 },
        { selector: '.play-button', delay: 300 },
        { selector: '.card-corner.top-left', delay: 500 },
        { selector: '.card-corner.top-right', delay: 600 },
        { selector: '.card-corner.bottom-left', delay: 700 },
        { selector: '.card-corner.bottom-right', delay: 800 }
    ];
    
    elements.forEach(({ selector, delay }) => {
        const element = document.querySelector(selector);
        if (element) {
            element.style.opacity = '0';
            element.style.transform = 'translateY(30px)';
            
            setTimeout(() => {
                element.style.transition = 'all 0.6s cubic-bezier(0.4, 0, 0.2, 1)';
                element.style.opacity = '1';
                element.style.transform = 'translateY(0)';
            }, delay);
        }
    });
}

// Función para ajustar el brillo según la hora del día
function adjustThemeByTime() {
    const hour = new Date().getHours();
    const body = document.body;
    
    if (hour >= 18 || hour <= 6) {
        // Modo nocturno - tonos más oscuros
        body.style.filter = 'brightness(0.9) contrast(1.1)';
    } else {
        // Modo diurno - tonos normales
        body.style.filter = 'brightness(1) contrast(1)';
    }
}

// Inicialización cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    console.log('🎮 BIKERS DECK - Triple J iniciado');
    
    // Inicializar todas las funcionalidades
    initializeParallaxEffect();
    initializeEntryAnimation();
    adjustThemeByTime();
    
    // Easter egg: doble clic en el logo
    const logo = document.querySelector('.logo-container');
    let clickCount = 0;
    
    logo.addEventListener('click', () => {
        clickCount++;
        if (clickCount === 2) {
            logo.style.animation = 'spin 1s ease-in-out';
            clickCount = 0;
            
            // Añadir animación de giro
            const style = document.createElement('style');
            style.textContent = `
                @keyframes spin {
                    from { transform: perspective(500px) rotateX(2deg) rotateY(0deg); }
                    to { transform: perspective(500px) rotateX(2deg) rotateY(360deg); }
                }
            `;
            document.head.appendChild(style);
        }
        
        setTimeout(() => {
            clickCount = 0;
        }, 500);
    });
});

// Función de utilidad para debug
function debugInfo() {
    console.log('🃏 Debug Info:');
    console.log('Game Started:', gameStarted);
    console.log('Current Overlay:', !!window.currentOverlay);
    console.log('Screen Size:', window.innerWidth + 'x' + window.innerHeight);
}