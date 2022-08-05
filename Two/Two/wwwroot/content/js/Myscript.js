const myModal = document.getElementById("staticBackdrop")
const myInput = document.getElementById('staticBackdrop')

myModal.addEventListener('shown.bs.modal', () => {
    myInput.focus()
})