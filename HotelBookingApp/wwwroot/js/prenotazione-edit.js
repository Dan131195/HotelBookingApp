$(document).ready(function () {
    // Funzione per aprire modale di modifica prenotazione
    $('.edit-btn').on('click', function () {
        let id = $(this).data('id');
        $.get('/Prenotazione/EditModal/' + id, function (html) {
            $('#modalContainer').html(html);
            let modal = new bootstrap.Modal(document.getElementById('editPrenotazioneModal'));
            modal.show();
        });
    });

    // Funzione per aprire modale di creazione prenotazione
    $('#btnCreate').on('click', function () {
        $.get('/Prenotazione/CreateModal', function (html) {
            $('#modalContainer').html(html);
            let modal = new bootstrap.Modal(document.getElementById('createPrenotazioneModal'));
            modal.show();
        });
    });

    // Funzione per aprire modale di eliminazione prenotazione
    $('.delete-btn').on('click', function () {
        let id = $(this).data('id');
        $.get('/Prenotazione/DeleteModal/' + id, function (html) {
            $('#modalContainer').html(html);
            let modal = new bootstrap.Modal(document.getElementById('deletePrenotazioneModal'));
            modal.show();
        });
    });

    // Funzione per aprire modale di dettagli prenotazione
    $('.details-btn').on('click', function () {
        let id = $(this).data('id');
        $.get('/Prenotazione/DetailsModal/' + id, function (html) {
            $('#modalContainer').html(html);
            let modal = new bootstrap.Modal(document.getElementById('detailsPrenotazioneModal'));
            modal.show();
        });
    });

    // Gestione submit modale modifica prenotazione
    $(document).on('submit', '#editPrenotazioneForm', function (e) {
        e.preventDefault();
        let form = $(this);
        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: form.serialize(),
            success: function () {
                location.reload(); // Oppure aggiorna dinamicamente la tabella
            },
            error: function () {
                alert('Errore durante la modifica della prenotazione.');
            }
        });
    });

    // Gestione submit modale creazione prenotazione
    $(document).on('submit', '#createPrenotazioneForm', function (e) {
        e.preventDefault();
        let form = $(this);
        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: form.serialize(),
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Errore durante la creazione della prenotazione.');
            }
        });
    });

    // Gestione submit modale eliminazione prenotazione
    $(document).on('submit', '#deletePrenotazioneForm', function (e) {
        e.preventDefault();
        let form = $(this);
        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: form.serialize(),
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Errore durante l\'eliminazione della prenotazione.');
            }
        });
    });
});
