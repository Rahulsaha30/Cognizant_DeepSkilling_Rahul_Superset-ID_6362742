import React from 'react';
import PostComponent from './PostComponent';

class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false
    };
  }

  
  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then((response) => response.json())
      .then((data) => {
        this.setState({ posts: data });
      })
      .catch((error) => {
        console.error("Fetch error:", error);
        this.setState({ hasError: true });
      });
  }

  componentDidMount() {
    this.loadPosts();
  }


  componentDidCatch(error, info) {
    alert('An error occurred while displaying posts!');
    console.error('Error:', error);
    console.log('Error Info:', info);
  }


  render() {
    return (
      <div>
        <h1>Posts</h1>
        {this.state.posts.map((post) => (
          <PostComponent
            key={post.id}
            title={post.title}
            body={post.body}
          />
        ))}
      </div>
    );
  }
}

export default Posts;
