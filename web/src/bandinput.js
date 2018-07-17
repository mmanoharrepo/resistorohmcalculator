import React from 'react';
import ReactDOM from 'react-dom';

export class BandInput extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="input-group">
                <label>{this.props.labelText}:</label>
                <select id={this.props.id} value={this.props.bandCode} onChange={this.props.handleChange} >
                    <option key='default' value=''>Select a Color</option>
                    {this.props.bandColorCodes.map((option, index) => (
                        <option key={index} value={option}>{option}</option>
                    ))}
                </select>
            </div>
        );
    }
}