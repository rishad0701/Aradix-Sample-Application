const API_URL = 'http://localhost:5048/api/MovieReview';

export const getMovies = async () =>{
    try{
        const responce = await fetch(`${API_URL}/GetMovies`);

        if(!responce.ok){
            throw new Error('Failed to fetch movies');
        }

        const data = await responce.json();
        return data;
    }catch (error){
        console.log('Error fetching movies:',error);
        return [];
    }
};


export const addMovie = async(movie) =>{
    try{
        const responce = await fetch(`${API_URL}/AddMovie`,{
            method: 'POST',
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify(movie),
        });
        if(!responce.ok){
            throw new Error('Failed to add movie');
        }
        const data = await responce.json();
        return data;
    }catch(error){
        console.log('Error adding movies:',error);
    }
};

export const updateMovie = async (movie)=>{
    try{
        const responce = await fetch(`${API_URL}/UpdateMovie`,{
            method : 'PUT',
            headers : {
                'Content-Type' : 'application/json'
            },
            body : JSON.stringify(movie),
        });
        if(!responce.ok){
            throw new Error('Failed to update movie');
        }
        const data = await responce.json();
        return data;
    }catch (error){
        console.log('Error updating movie',error);
    }
};

export const deleteMovie = async(movieId)=>{
    try{
        const responce = await fetch(`${API_URL}/DeleteMovie${movieId}`,{
            method : 'DELETE',
        })
        if(!responce.ok){
            throw new Error('Failed to delete movie');
        }

        const data = await responce.json();
        return data;
    }catch(error){
        console.log('Error deleting movie:',error);
    }
};

export const getMovieById = async (movieId)=>{
    try{
        const responce = await fetch(`${API_URL}/GetMovieById/${movieId}`,{
            method : 'GET',
        })
        if(!responce.ok){
            throw new Error('Failed to fetch movie');
        }
        const data = await responce.json();
        return data;
    }catch(error){
        console.log('Error while fetchiung movie:',error);
    }
}