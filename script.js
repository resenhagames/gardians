// Menu mobile
document.addEventListener('DOMContentLoaded', function () {
    var toggle = document.querySelector('.nav-toggle');
    var links = document.querySelector('.nav-links');

    if (toggle && links) {
        toggle.addEventListener('click', function () {
            links.classList.toggle('ativo');
        });

        // Fechar menu ao clicar em um link
        var itens = links.querySelectorAll('a');
        itens.forEach(function (item) {
            item.addEventListener('click', function () {
                links.classList.remove('ativo');
            });
        });
    }

    // Animação de entrada ao rolar
    var elementos = document.querySelectorAll(
        '.sobre-grid, .mecanica-item, .galeria-item, .timeline-item, .membro-card, .equipe-info'
    );

    elementos.forEach(function (el) {
        el.classList.add('fade-in');
    });

    function verificarVisibilidade() {
        elementos.forEach(function (el) {
            var rect = el.getBoundingClientRect();
            var visivel = rect.top < window.innerHeight - 80;
            if (visivel) {
                el.classList.add('visivel');
            }
        });
    }

    verificarVisibilidade();
    window.addEventListener('scroll', verificarVisibilidade);

    // Header com fundo ao rolar
    var header = document.querySelector('.header');
    window.addEventListener('scroll', function () {
        if (window.scrollY > 50) {
            header.style.borderBottomColor = 'rgba(93, 184, 212, 0.15)';
        } else {
            header.style.borderBottomColor = 'rgba(93, 184, 212, 0.1)';
        }
    });
});
