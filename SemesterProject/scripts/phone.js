$('#BodyPlaceholder_tbPhoneNumber').on('change', function () {
    let value = $(this).val()
    if(value.length !== 10) return
    let r = /(\D+)/g,
        npa = '',
        nxx = '',
        last4 = '';
    value = value.replace(r, '');
    npa = value.substr(0, 3);
    nxx = value.substr(3, 3);
    last4 = value.substr(6, 4);
    value = npa + '-' + nxx + '-' + last4;
    $(this).val(value)
})

$('.phone').on('change', function () {
    let value = $(this).val()
    if (value.length !== 10) return
    let r = /(\D+)/g,
        npa = '',
        nxx = '',
        last4 = '';
    value = value.replace(r, '');
    npa = value.substr(0, 3);
    nxx = value.substr(3, 3);
    last4 = value.substr(6, 4);
    value = npa + '-' + nxx + '-' + last4;
    $(this).val(value)
})