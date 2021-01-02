
function main() {
    const board = <HTMLCanvasElement> document.getElementById('tic-tac-toe-board');

    const size = 500;
    const lineColour = "#ddd";
    const lineStart = 4;
    const lineLength = size - 5;
    const sectionSize = size / 3;

    board.width = size;
    board.height = size;

    const elemLeft = board.offsetLeft + board.clientLeft;
    const elemTop = board.offsetTop + board.clientTop;
    const elemWidth = board.clientWidth;
    const elemHeight = board.clientHeight;

    board.addEventListener('click', ev => {
        const x = ev.pageX - elemLeft;
        const y = ev.pageY - elemTop;

        console.log(`X: ${x}, Y: ${y}`);
    });

    const ctx = board.getContext('2d');  
    if(ctx != null) {
        ctx.fillStyle = 'white';
        ctx.fillRect(0, 0, elemWidth, elemHeight);

        ctx.lineWidth = 10;
        ctx.lineCap = 'round';
        ctx.strokeStyle = lineColour;
        ctx.beginPath();

        for (let y = 1; y <= 2; y++) {  
            ctx.moveTo(lineStart, y * sectionSize);
            ctx.lineTo(lineLength, y * sectionSize);
        }
      
        for (let x = 1; x <= 2; x++) {
            ctx.moveTo(x * sectionSize, lineStart);
            ctx.lineTo(x * sectionSize, lineLength);
        }
      
        ctx.stroke();
    }
}
