const btns = document.querySelectorAll('.buy_button_button')
const modaloverlay = document.querySelector('.modal_overlay')
const modals_window = document.querySelector('.modal_window')
const btns_close = document.querySelector('.btn_close')
btns.forEach((el) => {
    el.addEventListener('click', (e) => {
        let path = e.currentTarget.getAttribute('data-path');
        document.querySelector('[data-target="' + path + '"]').classList.add('modal_window--visibly');
        modaloverlay.classList.add('modal_overlay--visible');
    })

})


modaloverlay.addEventListener('click', (e) => {
    console.log(e.target)
    if (e.target == modaloverlay) {
        modals_window.classList.remove('modal_window--visibly');
        modaloverlay.classList.remove('modal_overlay--visible');
    }


})
btns_close.addEventListener('click',(e)=>{
    if(e.target == btns_close){
        modals_window.classList.remove('modal_window--visibly');
        modaloverlay.classList.remove('modal_overlay--visible');
        }


})


