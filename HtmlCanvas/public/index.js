function main() {
    var board = document.getElementById('tic-tac-toe-board');
    var size = 500;
    var lineColour = "#ddd";
    var lineStart = 4;
    var lineLength = size - 5;
    var sectionSize = size / 3;
    board.width = size;
    board.height = size;
    var elemLeft = board.offsetLeft + board.clientLeft;
    var elemTop = board.offsetTop + board.clientTop;
    var elemWidth = board.clientWidth;
    var elemHeight = board.clientHeight;
    board.addEventListener('click', function (ev) {
        var x = ev.pageX - elemLeft;
        var y = ev.pageY - elemTop;
        console.log("X: " + x + ", Y: " + y);
    });
    var ctx = board.getContext('2d');
    if (ctx != null) {
        ctx.fillStyle = 'white';
        ctx.fillRect(0, 0, elemWidth, elemHeight);
        ctx.lineWidth = 10;
        ctx.lineCap = 'round';
        ctx.strokeStyle = lineColour;
        ctx.beginPath();
        for (var y = 1; y <= 2; y++) {
            ctx.moveTo(lineStart, y * sectionSize);
            ctx.lineTo(lineLength, y * sectionSize);
        }
        for (var x = 1; x <= 2; x++) {
            ctx.moveTo(x * sectionSize, lineStart);
            ctx.lineTo(x * sectionSize, lineLength);
        }
        ctx.stroke();
    }
}
