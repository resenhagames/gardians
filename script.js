document.addEventListener('DOMContentLoaded', () => {
    // Nav shrink on scroll
    const gameNav = document.getElementById('gameNav');

    window.addEventListener('scroll', () => {
        if (window.scrollY > 50) {
            gameNav.style.backgroundColor = 'rgba(20, 20, 20, 0.95)';
            gameNav.style.backdropFilter = 'blur(10px)';
            gameNav.style.padding = '0 0'; // Optional: shrink effect
        } else {
            gameNav.style.backgroundColor = 'var(--game-nav-bg)';
            gameNav.style.backdropFilter = 'none';
        }
    });

    // Smooth scroll for nav links
    document.querySelectorAll('.game-links a, .game-actions a').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const currentHref = this.getAttribute('href');

            // Allow default behavior for external/login links
            if (currentHref === '#' || currentHref.startsWith('http')) return;

            e.preventDefault();
            const targetId = currentHref.substring(1);
            const targetSection = document.getElementById(targetId);

            if (targetSection) {
                // Adjusting for the fixed nav height (60px)
                const targetPosition = targetSection.getBoundingClientRect().top + window.scrollY - 60;
                window.scrollTo({
                    top: targetPosition,
                    behavior: 'smooth'
                });
            }
        });
    });

    // Scroll Reveal Animation (Intersection Observer)
    const revealElements = document.querySelectorAll('.reveal-up, .reveal-left, .reveal-right');

    const revealCallback = (entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-revealed');
                // Optional: stop observing once revealed
                // observer.unobserve(entry.target);
            }
        });
    };

    const revealOptions = {
        root: null,
        rootMargin: '0px 0px -100px 0px', // Trigger slightly before it hits the bottom
        threshold: 0.1
    };

    const observer = new IntersectionObserver(revealCallback, revealOptions);

    revealElements.forEach(el => {
        observer.observe(el);
    });
});
