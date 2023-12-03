document.addEventListener('DOMContentLoaded', function () {
    const scenes = document.querySelectorAll('.scene');
    let currentScene = 0;
    let intervalId;  // Alterado de const para let

    function showScene(index) {
        scenes[index].style.opacity = 1;
        scenes[index].style.pointerEvents = 'auto';
    }

    function hideScene(index) {
        scenes[index].style.opacity = 0;
        scenes[index].style.pointerEvents = 'none';
    }

    function switchScene() {
        hideScene(currentScene);
        currentScene = (currentScene + 1) % scenes.length;
        showScene(currentScene);
    }

    // Mostra a primeira cena ao carregar a página
    showScene(currentScene);

    // Inicia o intervalo para alternar automaticamente as cenas a cada 3 segundos (3000 milissegundos)
    intervalId = setInterval(switchScene, 3000);  // Corrigido para let

    // Pausa o intervalo quando o mouse entra na área da animação
    document.querySelector('.animation-container').addEventListener('mouseenter', function () {
        clearInterval(intervalId);
    });

    // Reinicia o intervalo quando o mouse sai da área da animação
    document.querySelector('.animation-container').addEventListener('mouseleave', function () {
        // Aguarde 1 segundo antes de retomar o intervalo para evitar problemas com a transição de opacidade
        setTimeout(() => {
            intervalId = setInterval(switchScene, 3000);
        }, 1000);
    });
});
