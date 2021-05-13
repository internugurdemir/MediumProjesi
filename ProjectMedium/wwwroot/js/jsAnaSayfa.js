
window.onload = function () {

    var changeTitle = "Where are you?";
    var pageTitle = document.title;
    var attentionMessage = '😢😢😢😢😢😢';
    var blinkEvent = null;

    document.addEventListener('visibilitychange', function (e) {
        var isPageActive = !document.hidden;

        if (!isPageActive) {
            blink();
        } else {
            document.title = pageTitle;
            clearInterval(blinkEvent);
        }
    });

    function blink() {
        blinkEvent = setInterval(function () {
            if (document.title === attentionMessage) {
                document.title = changeTitle;
            } else {
                document.title = attentionMessage;
            }
        }, 100);
    }
};