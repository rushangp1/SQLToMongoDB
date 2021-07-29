import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    onClick = () => {
        fetch('')
    }

    render() {
        return (
            <div>
                <button className="btn btn-primary" onClick={this.onClick}>Migrate Data</button>
            </div>
        );
    }
}
