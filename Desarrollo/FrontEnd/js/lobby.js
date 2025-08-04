const players = [
    { name: "Juan", avatar: "/Img/avatar1.png" },
    { name: "Luisa", avatar: "/Img/avatar2.png" },
    { name: "Carlos", avatar: "avatar3.png" },
    { name: "Diana", avatar: "avatar4.png" }
];

let currentPlayerIndex = null;

function renderPlayers() {
    const playersList = document.getElementById("playersList");
    playersList.innerHTML = "";

    players.forEach((player, index) => {
        playersList.innerHTML += `
            <div class="player-card">
                <img src="/Img/${player.avatar}" class="avatar" alt="${player.name}">
                <h3>${player.name}</h3>
                <button onclick="openAvatarSelector(${index})">Cambiar avatar</button>
            </div>
        `;
    });
}

function openAvatarSelector(index) {
    currentPlayerIndex = index;
    document.getElementById("avatarSelector").style.display = "block";
}

function cancelSelection() {
    currentPlayerIndex = null;
    document.getElementById("avatarSelector").style.display = "none";
}

function selectAvatar(filename) {
    if (currentPlayerIndex !== null) {
        players[currentPlayerIndex].avatar = filename;
        renderPlayers();
        cancelSelection();
    }
}

// Inicializar
document.addEventListener("DOMContentLoaded", renderPlayers);
