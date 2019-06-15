import {  connect } from 'react-redux'
import Counter from './../components/Counter';

const mapStateToProps = (state: any) => {
    return {
        value: state as number
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        onIncrement: () => dispatch({ type: 'INCREMENT' }),
        onDecrement: () => dispatch({ type: 'DECREMENT' }),
    }
}

export const CounterLink = connect(
    mapStateToProps,
    mapDispatchToProps
)(Counter);

export default CounterLink;