import React, { Component } from 'react';
import moment from 'moment';


export default class About extends Component {
    render() {
        var end = moment("20190519", "YYYYMMDD");
        var now = moment.now();
        return (
            <div>{end.diff(now, 'days') + 1}</div>
        );
    }
}