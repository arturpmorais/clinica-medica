$(document).ready(function () {
    $('.sidenav').sidenav({
        edge: 'left',
        closeOnClick: true,
        draggable: true
    });

    $('.collapsible').collapsible();

    $('.materialboxed').materialbox();

    $('.carousel.carousel-slider').carousel({
        fullWidth: true,
        indicators: true
    });

    $('select').formSelect();

    $('.modal').modal();

    $('.datanascimento').datepicker({
        format: 'dd/mm/yyyy',
        maxDate: new Date(),
        yearRange: 90,
        i18n: {
            cancel: 'Cancelar',
            clear: 'Limpar',
            done: 'Pronto',
            previousMonth: 'Mês anterior',
            nextMonth: 'Próximo mês',
            months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            weekdays: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sabádo'],
            weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
            weekdaysAbbrev: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S']
        }
    });

    $('.datanovaconsulta').datepicker({
        format: 'dd/mm/yyyy',
        //minDate: new Date(new Date().setDate(new Date().getDate() + 1)), // no mínino o dia seguinte
        minDate: new Date(),
        yearRange: 2,
        container: $('.containerpicker'),
        i18n: {
            cancel: 'Cancelar',
            clear: 'Limpar',
            done: 'Pronto',
            previousMonth: 'Mês anterior',
            nextMonth: 'Próximo mês',
            months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            weekdays: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sabádo'],
            weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
            weekdaysAbbrev: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S']
        }
    });

    $('.horarionovaconsulta').timepicker({
        container: '.containerpicker',
        twelveHour: false,
        i18n: {
            cancel: 'Cancelar',
            done: 'Pronto'
        },
        vibrate: true
    });
});