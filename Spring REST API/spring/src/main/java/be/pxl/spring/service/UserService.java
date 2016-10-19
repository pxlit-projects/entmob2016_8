package be.pxl.spring.service;

import java.security.NoSuchAlgorithmException;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;
import be.pxl.spring.repository.UserRepository;

@Service
@Transactional(readOnly = true)
public class UserService {	 

	  @Autowired
	  private UserRepository repository;
	  
	  @Transactional
	  public User save(User u) {
	    return repository.save(u);
	  }
	  
	  @Transactional 
	  public User findOne(int id){
		  return repository.findOne(id);
	  }
	  
	  @Transactional 
	public List<User> findByName(String name) {
		// TODO Auto-generated method stub
		return repository.findByName(name);
	}
	  @Transactional
	  public List<User> findByDepartment(String department){
		  return repository.findByDepartment(department);
	  }

}
