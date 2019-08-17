import React from "react";
import "./AniButton.css";
import anime from "animejs";

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
      <main>
        <div className="button" onClick={this.handleOnClick}>
          <div className="text" onClick={this.handleOnClick}>Submit</div>
        </div>
        <div className="progress"></div>
        <svg x="0px" y="0px"
          viewBox="0 0 25 30">
          <path ref={this.checkRef} className="check st0" d="M2,19.2C5.9,23.6,9.4,28,9.4,28L23,2" />
        </svg>
      </main>
    )
  }
}

