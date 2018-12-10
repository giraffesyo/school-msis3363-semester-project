$('.headshot').on('click', function () {
    const name = $(this).data('name')
    const title = $(this).data('title')
    replaceText(name, title)
})

function replaceText(name, title) {
    const element = `<div class="d-inline-block " data-aos="fade-right" data-aos-duration="750">
                        <h2>${name}</h2>
                        <h4>${title}</h4>
                    </div>`
    $('.AsideHeadshots').fadeOut('fast', function () {
        $(this).children().replaceWith(element)
        $(this).fadeIn('fast')
    })
}