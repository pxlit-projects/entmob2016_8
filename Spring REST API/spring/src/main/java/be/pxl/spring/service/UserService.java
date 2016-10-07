package be.pxl.spring.service;

import javax.persistence.*;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;
import be.pxl.spring.repository.UserRepository;

public class UserService {
	 @PersistenceContext
	  private EntityManager em;

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

}
