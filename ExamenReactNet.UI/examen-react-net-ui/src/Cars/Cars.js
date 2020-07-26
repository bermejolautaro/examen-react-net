import React from 'react';
import './Cars.css';

class Cars extends React.Component {
  constructor() {
    super();
    this.state = {
      cars: []
    }
  }

  componentDidMount() {
    fetch('http://localhost:5000/api/cars')
      .then(res => res.json().then(data => this.setState({ cars: data })));
  }

  render() {
    return (
      <div>
        {this.state.cars.map(c => this.getCars(c))}
      </div>
    )
  }

  getCars(c) {
    return (
      <div key={c.id} className="car">
       <div>License plate: {c.licensePlate}</div> 
        <div>Model: {c.model}</div>
        <div>Doors: {c.doors}</div>
        <div>Brand: {c.brand.name}</div>
        <div>Owner email: {c.owner}</div>
      </div>
    );
  }
}

export default Cars;