// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Portal Mahasiswa - Enhanced User Experience

// Mobile menu functionality
function toggleMobileMenu() {
    const mobileMenu = document.getElementById('mobile-menu');
    if (mobileMenu) {
        mobileMenu.classList.toggle('hidden');
        
        // Add animation class
        if (!mobileMenu.classList.contains('hidden')) {
            mobileMenu.classList.add('animate-fade-in');
        }
    }
}

// Close mobile menu when clicking outside
document.addEventListener('click', function(event) {
    const mobileMenu = document.getElementById('mobile-menu');
    const menuButton = event.target.closest('[onclick="toggleMobileMenu()"]');
    
    if (mobileMenu && !mobileMenu.contains(event.target) && !menuButton) {
        mobileMenu.classList.add('hidden');
    }
});

// Enhanced form validation feedback
document.addEventListener('DOMContentLoaded', function() {
    // Add smooth scrolling to validation errors
    const validationSummary = document.querySelector('[data-valmsg-summary]');
    if (validationSummary && validationSummary.innerHTML.trim()) {
        validationSummary.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }

    // Enhanced input focus effects
    const inputs = document.querySelectorAll('input[type="text"], input[type="email"], input[type="tel"], input[type="date"], textarea, select');
    inputs.forEach(input => {
        input.addEventListener('focus', function() {
            this.parentElement.classList.add('ring-2', 'ring-primary-500', 'ring-opacity-50');
        });
        
        input.addEventListener('blur', function() {
            this.parentElement.classList.remove('ring-2', 'ring-primary-500', 'ring-opacity-50');
        });
    });

    // Loading state for form submissions
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            const submitButton = form.querySelector('button[type="submit"], input[type="submit"]');
            if (submitButton) {
                const originalText = submitButton.textContent || submitButton.value;
                const isButton = submitButton.tagName.toLowerCase() === 'button';
                
                // Add loading state
                submitButton.disabled = true;
                if (isButton) {
                    submitButton.innerHTML = `
                        <svg class="animate-spin -ml-1 mr-3 h-4 w-4 text-white inline" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                            <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                            <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                        </svg>
                        Memproses...
                    `;
                } else {
                    submitButton.value = 'Memproses...';
                }

                // Reset after 5 seconds if form hasn't been submitted (fallback)
                setTimeout(() => {
                    if (submitButton.disabled) {
                        submitButton.disabled = false;
                        if (isButton) {
                            submitButton.textContent = originalText;
                        } else {
                            submitButton.value = originalText;
                        }
                    }
                }, 5000);
            }
        });
    });

    // Smooth animations for elements coming into view
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-fade-in');
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    // Observe elements that should animate on scroll
    const animateElements = document.querySelectorAll('.card-hover, .bg-white');
    animateElements.forEach(el => observer.observe(el));

    // Table row hover effects
    const tableRows = document.querySelectorAll('tbody tr');
    tableRows.forEach(row => {
        row.addEventListener('mouseenter', function() {
            this.classList.add('bg-gray-50', 'scale-[1.01]');
        });
        
        row.addEventListener('mouseleave', function() {
            this.classList.remove('bg-gray-50', 'scale-[1.01]');
        });
    });

    // Alert auto-dismiss
    const alerts = document.querySelectorAll('.alert-dismissible');
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.style.opacity = '0';
            alert.style.transform = 'translateY(-10px)';
            setTimeout(() => alert.remove(), 300);
        }, 5000);
    });
});

// Utility functions
const Utils = {
    // Format Indonesian currency
    formatCurrency: (amount) => {
        return new Intl.NumberFormat('id-ID', {
            style: 'currency',
            currency: 'IDR'
        }).format(amount);
    },

    // Format Indonesian date
    formatDate: (date) => {
        return new Intl.DateTimeFormat('id-ID', {
            weekday: 'long',
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        }).format(new Date(date));
    },

    // Show toast notification
    showToast: (message, type = 'info') => {
        const toast = document.createElement('div');
        const bgColor = {
            success: 'bg-green-500',
            error: 'bg-red-500',
            warning: 'bg-yellow-500',
            info: 'bg-blue-500'
        }[type];

        toast.className = `fixed top-4 right-4 ${bgColor} text-white px-6 py-3 rounded-lg shadow-lg z-50 transform translate-x-full transition-transform duration-300`;
        toast.textContent = message;
        
        document.body.appendChild(toast);
        
        // Animate in
        setTimeout(() => {
            toast.classList.remove('translate-x-full');
        }, 100);
        
        // Auto remove
        setTimeout(() => {
            toast.classList.add('translate-x-full');
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    }
};

// Export utilities for global use
window.PortalUtils = Utils;
