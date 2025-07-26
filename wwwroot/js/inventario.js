document.addEventListener("DOMContentLoaded", function () {
    // Confirmar antes de eliminar
    document.querySelectorAll(".btn-eliminar").forEach(function (btn) {
        btn.addEventListener("click", function (e) {
            if (!confirm("�Est� seguro que desea eliminar este movimiento?")) {
                e.preventDefault();
            }
        });
    });

    // Redirigir a editar (opcional, si quieres manejarlo por JS)
    document.querySelectorAll(".btn-editar").forEach(function (btn) {
        btn.addEventListener("click", function (e) {
            // Puedes agregar l�gica extra aqu� si lo necesitas
        });
    });
});