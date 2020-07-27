import React from 'react';
import Autocomplete from '../Autocomplete/Autocomplete';
import './CarForm.css';

class CarForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      canSubmit: false,
      brands: [],
      licensePlate: '',
      brandId: 1,
      model: '',
      doors: 0,
      ownerEmail: ''
    };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.updateForm = this.updateForm.bind(this);
  }

  componentDidMount() {
    fetch('http://localhost:5000/api/brands')
    .then(res => res.json().then(data => this.setState({ brands: data })));
  }

  updateForm(newState) {
    this.setState(newState, () => {
      const validations = [
        !!this.state.licensePlate && this.state.licensePlate.length === 8,
        !!this.state.model,
        this.state.doors > 0,
        !!this.state.ownerEmail
      ]

      this.setState({ canSubmit: validations.every(v => !!v) });
    });

  }

  handleSubmit(event) {
    const data = {
      licensePlate: this.state.licensePlate,
      brandId: parseInt(this.state.brandId, 10),
      model: this.state.model,
      doors: parseInt(this.state.doors, 10),
      owner: this.state.ownerEmail
    };

    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      mode: 'cors',
      body: JSON.stringify(data)
    };

    fetch('http://localhost:5000/api/cars', requestOptions)
      .then(() => window.location.reload(false));
    event.preventDefault();
  }

  render() {
    return (
      <div className="form-container">
        <form onSubmit={this.handleSubmit}>
          <label className="form-row">
            License Plate
          <input
              type="text"
              className="carform-input"
              maxLength="8"
              value={this.state.licensePlate}
              onChange={(event) => this.updateForm({ licensePlate: event.target.value })}
            />
          </label>

          <label className="form-row">
            Brand
            {this.getBrands()}
          </label>

          <label className="form-row">
            Model
            <textarea
              className="carform-textarea"
              value={this.state.model}
              onChange={(event) => this.updateForm({ model: event.target.value })}>
            </textarea>
          </label>

          <label className="form-row">
            Doors
            <input
              className="carform-input"
              type="number"
              value={this.state.doors}
              onChange={(event) => this.updateForm({ doors: event.target.value })}
            />
          </label>

          <div className="form-row">
            <Autocomplete 
              inputClassName="carform-input"
              onChange={(value) => this.updateForm({ ownerEmail: value })} />
          </div>
          <input 
            className="carform-submit"
            type="submit" 
            value="Submit" 
            disabled={!this.state.canSubmit} />
        </form>
      </div>

    );
  }

  getBrands() {
    return (
      <select 
        className="carform-select"
        value={this.state.brand} 
        onChange={(event) => this.updateForm({ brandId: event.target.value })}>
        {
          this.state.brands.map((brand) => {
            return (
              <option key={brand.brandId} value={brand.brandId}>
                {brand.brandName}
              </option>
            )
          })
        }
      </select>
    );
  }
}

export default CarForm;