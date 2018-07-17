import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import { BandInput } from './bandinput';

class OhmValueCalculator extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            resistorOhmValue: {
                ohmValue: '',
                maxValue: '',
                minValue: ''
            },
            bandColorCodes: {
                firstBandColorCodes: [],
                secondBandColorCodes: [],
                thirdBandColorCodes: [],
                fourthBandColorCodes: []
            },
            firstBandCode: '',
            secondBandCode: '',
            thirdBandCode: '',
            fourthBandCode: '',
            error: undefined
        };

        this.calculateOhmValue = this.calculateOhmValue.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    componentDidMount() {
        axios.get('http://localhost:57489/OhmValue/GetBandCodes')
            .then(response => {
                const bandColorCodes = response.data;
                this.setState(() => ({ bandColorCodes }));
            })
            .catch((error) => {
                if(error.response.status === '400'){
                    this.setState(() => ({ error: 'Error occured while processing the request!!' }));
                }
                else
                {
                    this.setState(() => ({ error: 'Unknown occured while processing the request!!' }));
                }
            });
    }

    handleChange(e) {
        if (e.target.id === 'firstBand') {
            const firstBandCode = e.target.value;
            this.setState({ firstBandCode });
        }
        else if (e.target.id === 'secondBand') {
            const secondBandCode = e.target.value;
            this.setState({ secondBandCode });
        }
        else if (e.target.id === 'thirdBand') {
            const thirdBandCode = e.target.value;
            this.setState({ thirdBandCode });
        }
        else if (e.target.id === 'fourthBand') {
            const fourthBandCode = e.target.value;
            this.setState({ fourthBandCode });
        }
    };

    calculateOhmValue(e) {
        e.preventDefault();
        const inputRequest = {
            bandAColor: e.target.firstBand.value,
            bandBColor: e.target.secondBand.value,
            bandCColor: e.target.thirdBand.value,
            bandDColor: e.target.fourthBand.value,
        }

        axios.post('http://localhost:57489/OhmValue/Calculate', inputRequest)
            .then((response) => {
                this.setState(() => ({ resistorOhmValue: response.data }));
            })
            .catch((error) => {
                if(error.response.status === '400'){
                    this.setState(() => ({ error: 'Error occured while processing the request!!' }));
                }
                else
                {
                    this.setState(() => ({ error: 'Unknown occured while processing the request!!' }));
                }
            });
    }

    render() {
        return (
            <div>
                <h2 className="headline">Ohm Value Calculator</h2>
                <form onSubmit={this.calculateOhmValue} className="calculator">
                    <h3>Select the color for all the bands:</h3>
                    {this.state.error && <h3 className="error">{this.state.error}</h3>}
                    <BandInput id="firstBand"
                        labelText="First Band"
                        bandCode={this.state.firstBandCode}
                        handleChange={this.handleChange} bandColorCodes={this.state.bandColorCodes.firstBandColorCodes} />
                    <BandInput id="secondBand"
                        labelText="Second Band"
                        bandCode={this.state.secondBandCode}
                        handleChange={this.handleChange} bandColorCodes={this.state.bandColorCodes.secondBandColorCodes} />
                    <BandInput id="thirdBand"
                        labelText="Third Band"
                        bandCode={this.state.thirdBandCode}
                        handleChange={this.handleChange} bandColorCodes={this.state.bandColorCodes.thirdBandColorCodes} />
                    <BandInput id="fourthBand"
                        labelText="Fourth Band"
                        bandCode={this.state.fourthBandCode}
                        handleChange={this.handleChange} bandColorCodes={this.state.bandColorCodes.fourthBandColorCodes} />
                    <div className="input-group">
                        <button className="primary-button" disabled={!this.state.firstBandCode ||
                            !this.state.secondBandCode ||
                            !this.state.thirdBandCode ||
                            !this.state.fourthBandCode}>Calculate OhmValue</button>
                    </div>
                    <div className="result-group">
                        <label>Ohm Value:</label>
                        <label>{this.state.resistorOhmValue.ohmValue}</label>
                    </div>
                    <div className="result-group">
                        <label>Max Value:</label>
                        <label>{this.state.resistorOhmValue.maxValue}</label>
                    </div>
                    <div className="result-group">
                        <label>Min Value:</label>
                        <label>{this.state.resistorOhmValue.minValue}</label>
                    </div>
                </form>
            </div>
        );
    }
}

const appRoot = document.getElementById('app');
ReactDOM.render(<OhmValueCalculator />, appRoot);