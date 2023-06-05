document.addEventListener('DOMContentLoaded', function () {
    var commentInputs = document.querySelectorAll('.text');

    commentInputs.forEach(function (commentInput) {
        commentInput.addEventListener('input', function (event) {
            var inputValue = event.target.value;
            var newValue = inputValue.replace(/\s{2,}/g, ' ');

            if (newValue !== inputValue) {
                event.target.value = newValue;
            }
        });
    });
});







