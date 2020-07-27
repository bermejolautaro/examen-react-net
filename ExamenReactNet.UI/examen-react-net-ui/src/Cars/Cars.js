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
      <table className="cars-table">
        <thead>
        <tr className="cars-table-header">
          <th>License Plate</th>
          <th>Model</th>
          <th>Doors</th>
          <th>Brand</th>
          <th>Owner Email</th>
        </tr>
        </thead>
        <tbody>
          {this.state.cars.map(c => this.getCars(c))}
        </tbody>
      </table>
    )
  }

  getCars(c) {
    return (
      <tr key={c.carId} className="car">
        <td className="cars-license-plate-row">{c.licensePlate}</td>
        <td>{c.model}</td>
        <td>{c.doors}</td>
        <td>{c.brandName}</td>
        <td>{c.ownerEmail}</td>
      </tr>
    );
  }
}

export default Cars;