
        function startGame(event) {
            event.preventDefault();
            const playerName = document.querySelector('.player-input').value.trim();
            
            if (playerName) {
                // Aquí puedes agregar la lógica para continuar al siguiente paso
                console.log('Jugador:', playerName);
                alert(`¡Bienvenido ${playerName}! Iniciando juego...`);
                // Redirigir a la siguiente pantalla o iniciar el juego
            }
        }

        // Efecto de partículas opcional
        document.addEventListener('mousemove', function(e) {
            const cursor = document.createElement('div');
            cursor.style.position = 'fixed';
            cursor.style.left = e.clientX + 'px';
            cursor.style.top = e.clientY + 'px';
            cursor.style.width = '2px';
            cursor.style.height = '2px';
            cursor.style.background = '#ff6b00';
            cursor.style.borderRadius = '50%';
            cursor.style.pointerEvents = 'none';
            cursor.style.zIndex = '9999';
            cursor.style.animation = 'fadeOut 1s ease-out forwards';
            
            document.body.appendChild(cursor);
            
            setTimeout(() => {
                cursor.remove();
            }, 1000);
        });

        // Añadir animación fadeOut
        const style = document.createElement('style');
        style.textContent = `
            @keyframes fadeOut {
                to {
                    opacity: 0;
                    transform: scale(0);
                }
            }
        `;
        document.head.appendChild(style);