document.addEventListener("DOMContentLoaded", function () {
    // Redirigir a eliminar con confirmación
    document.querySelectorAll(".btn-eliminar").forEach(function (btn) {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            if (confirm("¿Está seguro que desea eliminar este movimiento?")) {
                const tipoMovimiento = btn.getAttribute("data-tipo");
                const nroDocumento = btn.getAttribute("data-nro");
                window.location.href = `/MovInventario/Eliminar?tipoMovimiento=${tipoMovimiento}&nroDocumento=${nroDocumento}`;
            }
        });
    });

    // Redirigir a editar
    document.querySelectorAll(".btn-editar").forEach(function (btn) {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            const tipoMovimiento = btn.getAttribute("data-tipo");
            const nroDocumento = btn.getAttribute("data-nro");
            window.location.href = `/MovInventario/Editar?tipoMovimiento=${tipoMovimiento}&nroDocumento=${nroDocumento}`;
        });
    });
});