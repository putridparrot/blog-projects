import React from "react";
//import "./AniButton.css";
import anime from "animejs";

const styles = {
  main: {
    height: "100vh",
    width: "100vw"
  },
  button: {
    background: "#2B2D2F",
    height: "80px",
    width: "200px",
    textAlign: "center",
    position: "absolute",
    top: "50%",
    transform: "translateY(-50%)",
    left: "0",
    right: "0",
    margin: "0 auto",
    cursor: "pointer",
    borderRadius: "4px"
  },
  text: {
    font: "bold 1.25rem/1 poppins",
    color: "#71DFBE",
    position: "absolute",
    top: "50%",
    transform: "translateY(-52%)",
    left: "0",
    right: "0"
  },
  progress: {
    position: "absolute",
    height: "10px",
    width: "0",
    right: "0",
    top: "50%",
    left: "50%",
    borderRadius: "200px",
    transform: "translateY(-50%) translateX(-50%)",
    background: "gray",
  },
  svg: {
    width: "30px",
    position: "absolute",
    top: "50%",
    transform: "translateY(-50%) translateX(-50%)",
    left: "50%",
    right: "0",
    enableBackground: "new 0 0 25 30"
  },
  check: {
    fill: "none",
    stroke: "#FFFFFF",
    strokeWidth: "3",
    strokeLinecap: "round",
    strokeLinejoin: "round",
    opacity: "0"
  }   
}

function AnimatedButton(props) {
}

export class AniButton extends React.Component {

  checkRef = React.createRef();

  constructor(props) {
    super(props);

    this.handleOnClick = this.handleOnClick.bind(this);
  }

  handleOnClick() {

    var pathEls = this.checkRef.current;
    var offset = anime.setDashoffset(pathEls);
    pathEls.setAttribute("stroke-dashoffset", offset);

    var basicTimeline = anime.timeline({
      autoplay: false
    })
    .add({
      targets: ".text",
      duration: 1,
      opacity: 0
    })
    .add({
      targets: ".button",
      duration: 1300,
      height: 10,
      width: 300,
      backgroundColor: "#2B2D2F",
      border: "0",
      borderRadius: 100
    })
    .add({
      targets: ".progress",
      duration: 2000,
      width: 300,
      easing: "linear"
    })
    .add({
      targets: ".button",
      width: 0,
      duration: 1
    })
    .add({
      targets: ".progress",
      width: 80,
      height: 80,
      delay: 500,
      duration: 750,
      borderRadius: 80,
      backgroundColor: "#71DFBE"
    })
    .add({
      targets: pathEls,
      strokeDashoffset: [offset, 0],
      opacity: 1,
      duration: 200,
      easing: "easeInOutSine"
    });

    basicTimeline.play();
  }

  render() {
    return (
      <main style={styles.main}>
        <div className="button" style={styles.button} onClick={this.handleOnClick}>
          <div className="text" style={styles.text} onClick={this.handleOnClick}>Submit</div>
        </div>
        <div className="progress" style={styles.progress}></div>
        <svg x="0px" y="0px"
          viewBox="0 0 25 30" style={styles.svg}>
          <path ref={this.checkRef} style={styles.check} className="check st0" d="M2,19.2C5.9,23.6,9.4,28,9.4,28L23,2" />
        </svg>
      </main>
    )
 
//    return <AnimatedButton />
  }
}

