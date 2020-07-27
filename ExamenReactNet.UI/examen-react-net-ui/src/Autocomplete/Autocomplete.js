import React from 'react';
import './Autocomplete.css';

class Autocomplete extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isOpen: false,
      users: [],
      search: '',
    }

    this.handleChange = this.handleChange.bind(this);
    this.handleClick = this.handleClick.bind(this);
  }

  getSearchResults() {
    if(!this.state.isOpen) 
      return;

    return this.state.users
      .filter(user => this.userNameContainsSearchValue(user))
      .map((user) => {
        return (
          <div key={user.id} className="search-result">
            <img className="avatar" src={user.avatar} alt={user.first_name}></img>
            <div onClick={() => this.handleClick(user)}>{user.first_name} {user.last_name}</div>
          </div>
        )
      })
  }

  userNameContainsSearchValue(u) {
    return `${u.first_name} ${u.last_name}`.toLocaleLowerCase().indexOf(this.state.search.toLocaleLowerCase()) > -1;
  }
  
  updateUsers(data) {
    return this.setState({ users: this.state.users.concat(data).sort((a, b) => a.id - b.id) });
  }

  handleChange(event) {
    this.props.onChange(null);
    this.setState({search: event.target.value}, () => {
      this.setState({isOpen: !!this.state.search && !!this.state.search.length})
    });
  }

  handleClick(user) {
    this.props.onChange(user.email);
    this.setState({search: `${user.first_name} ${user.last_name}`})
    this.setState({isOpen: false});
  }

  componentDidMount() {
    const promises = 
      new Array(3)
        .fill()
        .map((_, index) => fetch(`https://reqres.in/api/users?page=${index + 1}`));

    Promise.all(promises)
           .then(usersArray => usersArray.map(res => res.json().then(({data}) => this.updateUsers(data))))
  }

  render() {
    return (
      <div className="autocomplete">
        <div>Owner</div>
        <input id="autocomplete"
               className={`autocomplete-input ${this.props.inputClassName}`}
               placeholder="Search"
               value={this.state.search}
               onChange={(event) => this.handleChange(event)}>
        </input>
        <div className="search-results">
          {this.getSearchResults()}
        </div>
      </div>
    )
  }
}

export default Autocomplete;